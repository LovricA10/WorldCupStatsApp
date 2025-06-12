using Dao.Api;
using Dao.Enums;
using Dao.Models;
using Dao.Repo;
using Dao.Utilitly;
using Dao.Utility;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WpfApp.UserControls;


namespace WpfApp.Forms
{
    public partial class WorldCup : Window
    {
        private readonly IApi api = ApiFactory.GetApi();
        private readonly IRepository repository = RepositoryFactory.GetRepository();

        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public WorldCup()
        {
            ApplyCulture();
            InitializeComponent();
            SetInitialWindowSize();
        }

        private void SetInitialWindowSize()
        {
            switch (repository.GetSavedWindowSize()?.ToLowerInvariant())
            {
                case "small":
                    WindowState = WindowState.Normal;
                    Width = 800;
                    Height = 600;
                    break;
                case "medium":
                    WindowState = WindowState.Normal;
                    Width = 1024;
                    Height = 768;
                    break;
                case "fullscreen":
                    WindowState = WindowState.Maximized;
                    break;
                default:
                    WindowState = WindowState.Normal;
                    Width = 800;
                    Height = 600;
                    break;
            }
        }

        private void ApplyCulture()
        {
            try
            {
                var lang = repository.GetStoredLanguage();
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            catch 
            { 
                // fallback to default lang 
            }
        }
        

        private void WorldCup_OnLoaded(object sender, RoutedEventArgs e)
        {
           LoadTeamsAsync(CbHomeTeam);
        }

        private async void LoadTeamsAsync(ComboBox combo)
        {
            combo.Items.Clear();
            try
            {
                var gender = Enum.Parse<GenderType>(repository.GetStoredGender(), ignoreCase: true);
                var endpoint = EndpointBuilder.BuildTeamsEndpoint(gender);
                var teams = await api.GetDataAsync<IList<Team>>(endpoint);
                foreach (var team in teams)
                    combo.Items.Add(team);
            }
            catch (Exception)
            {
                ShowError();
            }
        }

        private void ShowError()
        {
            string title = Properties.Resources.ErrorTitle;
            string message = Properties.Resources.ErrorMessage;
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void WorldCup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string title = Properties.Resources.confirmCloseTItle;
            string message = Properties.Resources.confirmCloseText;

            if (MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question) != MessageBoxResult.OK)
                e.Cancel = true;
        }

        private void BtnHomeTeamInformation_Click(object sender, RoutedEventArgs e)
        => ShowTeamStats(CbHomeTeam.SelectedItem as Team);


        private void BtnAwayTeamInformation_Click(object sender, RoutedEventArgs e)
        => ShowTeamStats(CbAwayTeam.SelectedItem as Team);

        private async void ShowTeamStats(dynamic team)
        {
            if (team == null) return;

            try
            {
                var gender = Enum.Parse<GenderType>(repository.GetStoredGender(), ignoreCase: true);
                var endpoint = EndpointBuilder.BuildTeamResultsEndpoint(gender);
                var results = await api.GetDataAsync<IList<TeamResult>>(endpoint);

                foreach (var r in results)
                {
                    Debug.WriteLine($"Team: {r.Country}, Played: {r.GamesPlayed}, Wins: {r.Wins}, Draws: {r.Draws}, Losses: {r.Losses}");
                }
                var stat = results.FirstOrDefault(r => r.Country == team.Country);
                new TeamInformation(
                        stat?.Country,
                        stat?.FifaCode,
                        stat?.Wins.ToString() ?? "Not available",
                        stat?.Draws.ToString() ?? "Not available",
                        stat?.Losses.ToString() ?? "Not available",
                        stat?.GamesPlayed.ToString() ?? "Not available",
                        stat?.GoalsFor.ToString() ?? "Not available",
                        stat?.GoalsAgainst.ToString() ?? "Not available"
                ).ShowDialog();
            }
            catch
            {
                ShowError();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new Settings().ShowDialog();
            Close();
        }

        private async void CbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HomeTeam = (sender as ComboBox).SelectedItem as Team;
            LoadOpponentsAsync(CbAwayTeam, HomeTeam?.Country);
            CbAwayTeam.SelectedIndex = -1;
        }
        private async void CbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AwayTeam = (sender as ComboBox)?.SelectedItem as Team;
            if (HomeTeam != null && AwayTeam != null)
            {
                await LoadMatchLineupsAsync();
            }
        }

        private async Task LoadMatchLineupsAsync()
        {
            if (HomeTeam == null || AwayTeam == null) return;

            try
            {
                ShowSpinner(true);
                await Task.Delay(50);

                var gender = Enum.Parse<GenderType>(repository.GetStoredGender(), ignoreCase: true);
                var endpoint = EndpointBuilder.BuildMatchesEndpoint(gender);
                var matches = await api.GetDataAsync<IList<MatchDetail>>(endpoint);

                var match = matches.FirstOrDefault(m =>
                    m.HomeTeamCountry?.Trim().ToLower() == HomeTeam.Country?.Trim().ToLower() &&
                    m.AwayTeamCountry?.Trim().ToLower() == AwayTeam.Country?.Trim().ToLower());

                if (match == null) return;

                TxtMatchResult.Text = $"{match.HomeTeam?.Goals ?? 0} : {match.AwayTeam?.Goals ?? 0}";
                ClearTeamPanels(false); // home
                ClearTeamPanels(true);  // away

                LoadLineup(match.HomeTeamStatistics?.StartingEleven, false);
                LoadLineup(match.AwayTeamStatistics?.StartingEleven, true);
            }
            catch
            {
                ShowError();
            }
            finally
            {
                ShowSpinner(false);
            }
        }

        private void LoadLineup(IEnumerable<StartingEleven>? players, bool isAwayTeam)
        {
            if (players == null) return;

            foreach (var player in players)
            {
                var playerControl = new PlayerUserControl(player.Name, player.ShirtNumber.ToString())
                {
                    MaxWidth = 120,
                    MaxHeight = 140,
                    BtnUserControl = { ClickMode = ClickMode.Press }
                };

                playerControl.BtnUserControl.Click += PlayerControl_Click;
                GetPanel(player.Position, isAwayTeam).Children.Add(playerControl);
            }
        }

        private async void LoadOpponentsAsync(ComboBox combo, string? homeTeamCountry)
        {
            combo.Items.Clear();
            if (string.IsNullOrEmpty(homeTeamCountry))
                return;
            try
            {
                var gender = Enum.Parse<GenderType>(repository.GetStoredGender(), ignoreCase: true);

                var teamsEndpoint = EndpointBuilder.BuildTeamsEndpoint(gender);
                var allTeams = await api.GetDataAsync<IList<Team>>(teamsEndpoint);

                var matchesEndpoint = EndpointBuilder.BuildMatchesEndpoint(gender);
                var matches = await api.GetDataAsync<IList<MatchDetail>>(matchesEndpoint);

                var opponentCountries = matches
                    .Where(m => m.HomeTeamCountry == homeTeamCountry)
                    .Select(m => m.AwayTeamCountry)
                    .Distinct()
                    .ToList();
                var opponents = allTeams
                    .Where(t => opponentCountries.Contains(t.Country))
                    .ToList();
                foreach (var opponent in opponents)
                    combo.Items.Add(opponent);
            }
            catch (Exception)
            {
                ShowError();
            }
        }
        private async void PlayerControl_Click(object sender, RoutedEventArgs e)
        {
          if (HomeTeam == null || AwayTeam == null) return;

        try
            {
               var gender = Enum.Parse<GenderType>(repository.GetStoredGender(), ignoreCase: true);
               var endpoint = EndpointBuilder.BuildMatchesEndpoint(gender);
               var matches = await api.GetDataAsync<IList<MatchDetail>>(endpoint);
               var match = matches.FirstOrDefault(m => 
               m.HomeTeamCountry?.Trim().ToLower() == HomeTeam?.Country?.Trim().ToLower() && m.AwayTeamCountry?.Trim().ToLower() == AwayTeam.Country?.Trim().ToLower());

               var button = sender as Button;
                if (button == null)
                {
                    ShowError();
                    return;
                }
                var viewbox = button.Content as Viewbox;
                var panel = viewbox?.Child as StackPanel;

                panel ??= button.Content as StackPanel;
                var label = panel?.Children.OfType<Label>().FirstOrDefault();

                if (label == null || label.Content == null)
                {
                    ShowError();
                    return;
                }

                var playerName = label.Content.ToString();

                var homePlayers = match?.HomeTeamStatistics?.StartingEleven ?? Enumerable.Empty<StartingEleven>();
                var awayPlayers = match?.AwayTeamStatistics?.StartingEleven ?? Enumerable.Empty<StartingEleven>();
                var player = homePlayers
                    .Union(awayPlayers)
                    .FirstOrDefault(p => p.Name == playerName);

                var homeEvents = match?.HomeTeamEvents ?? Enumerable.Empty<TeamEvent>();
                var awayEvents = match?.AwayTeamEvents ?? Enumerable.Empty<TeamEvent>();

                var events = homeEvents
                    .Concat(awayEvents)
                    .Where(ev => ev.Player == playerName);

               var goals = events.Count(ev => 
               ev.TypeOfEvent == TypeOfEvent.Goal || ev.TypeOfEvent == TypeOfEvent.GoalOwn
               || ev.TypeOfEvent == TypeOfEvent.GoalPenalty);
               var yellowCards = events.Count(ev => ev.TypeOfEvent == TypeOfEvent.YellowCard || ev.TypeOfEvent == TypeOfEvent.YellowCardSecond);

                if (player == null)
                {
                    MessageBox.Show("Player is null. Cannot show player info.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                new PlayerInformation(
                    player.Name,
                    player.ShirtNumber.ToString(),
                    player.Position.ToString(),
                    player.Captain.ToString().CapitalizeFirstLetter(),
                    goals.ToString(),
                    yellowCards.ToString()
                ).ShowDialog();
            }
            catch
            {
                ShowError();
            }
        }

        private Panel GetPanel(Position position, bool isAwayTeam)
        {
            return (position, isAwayTeam) switch
            {
                (Position.Goalie, false) => PnlHomeTeamGoalie,
                (Position.Defender, false) => PnlHomeTeamDefender,
                (Position.Midfield, false) => PnlHomeTeamMidfield,
                (Position.Forward, false) => PnlHomeTeamForward,
                (Position.Goalie, true) => PnlAwayTeamGoalie,
                (Position.Defender, true) => PnlAwayTeamDefender,
                (Position.Midfield, true) => PnlAwayTeamMidfield,
                (Position.Forward, true) => PnlAwayTeamForward,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void ShowSpinner(bool show)
        {
            LoadingSpinner.Visibility = show ? Visibility.Visible : Visibility.Hidden;
            LoadingSpinner.Spin = show;
        }

        private void ClearTeamPanels(bool isAwayTeam)
        {
            foreach (Position pos in Enum.GetValues(typeof(Position)))
            {
                GetPanel(pos, isAwayTeam).Children.Clear();
            }
           
        }

      
    }
}
