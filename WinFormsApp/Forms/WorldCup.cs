using Dao.Api;
using Dao.Enums;
using Dao.Models;
using Dao.Repo;
using Dao.Utilitly;
using Newtonsoft.Json;
using Syncfusion.WinForms.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.UserControls;

namespace WinFormsApp.Forms
{
    public partial class WorldCup : Form
    {

        private bool isFormFirstTimeShown = true;
        private int controlCounter = 0;
        private readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        private readonly IDictionary<string, int> playerGoals = new Dictionary<string, int>();
        private readonly IDictionary<string, int> playerYellowCards = new Dictionary<string, int>();
        private readonly IList<Control> draggableControls = new List<Control>();

        private readonly IApi api = ApiFactory.GetApi();
        private readonly IRepository repository = RepositoryFactory.GetRepository();

        public WorldCup()
        {  
            InitializeComponent();
            InitializeCulture();
            InitializeDragAndDrop();
            InitializeOpenFileDialog();
        }

        private void InitializeCulture()
        {
            var selectedLanguage = repository.GetStoredLanguage();
            LanguageHelper.ApplyCulture(selectedLanguage, this, GetType());
        }

        private void InitializeDragAndDrop()
        {
            flpAllPlayers.AllowDrop = true;
            flpFavoritePlayers.AllowDrop = true;
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog.Filter = @"Images|*.jpeg;*.jpg;*.png;|All files|*.*";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = Resources.Resources.loadImage;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var settingsForm = new Settings())
                {
                    settingsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while opening the settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void WorldCup_Activated(object sender, EventArgs e)
        {
            // Attempt to load the last selected team from settings
            if (isFormFirstTimeShown)
            {
                try
                {
                    var selectedTeam = repository.GetCurrentTeam();
                    if (selectedTeam != null)
                    {
                        await LoadPanelWithPlayersAsync(selectedTeam);

                        cbTeams.SelectedItem = cbTeams.Items
                         .OfType<Team>()
                         .FirstOrDefault(t => t.Country == selectedTeam);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed (if required)
                    Debug.WriteLine($"Failed to load selected team: {ex.Message}");

                    // Notify the user about the error
                    MessageBox.Show("An error occurred while loading the selected team. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    isFormFirstTimeShown = false;
                }
            }

            await LoadComboBoxWithTeamsAsync();
            InitializeCulture();
        }


        private void DisplayFavoritePlayers()
        {
            try
            {
                var favoritePlayers = repository.GetFavoritePlayersList();

                foreach (var player in favoritePlayers)
                {
                    var playerControl = Controls.Find(player.Trim(), true).FirstOrDefault() as PlayerUserControl;
                    if (playerControl != null)
                    {
                        playerControl.IsStarDisplayed = true;
                        flpAllPlayers.Controls.Remove(playerControl);
                        flpFavoritePlayers.Controls.Add(playerControl);
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log the exception or handle the error
                Debug.WriteLine($"Error loading favorite players: {ex.Message}");
            }
        }


        private async Task LoadComboBoxWithTeamsAsync()
        {
            cbTeams.Items.Clear();
            cbTeams.Text = Resources.Resources.cbTeamsLoading;

            try
            {
                // Get gender and build the endpoint for teams
                var teamGenderString = repository.GetStoredGender();
                var teamGender = Enum.TryParse(teamGenderString, out GenderType gender) ? gender : GenderType.Male;
                var endpoint = EndpointBuilder.BuildTeamsEndpoint(teamGender);

                // Fetch the teams data from the API
                var teams = await FetchTeamsAsync(endpoint);

                // Add teams to ComboBox
                AddTeamsToComboBox(teams);

                // Reset ComboBox text after loading
                cbTeams.Text = string.Empty;
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                // Handle errors by showing an error notification
                ShowErrorNotification();
            }
        }

        private void ShowErrorNotification()
        =>
            MessageBox.Show(Resources.Resources.CouldNotRetrieveData, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //private void AddTeamsToComboBox(IEnumerable<Team> teams) => teams.ToList().ForEach(team => cbTeams.Items.Add(team));
        private void AddTeamsToComboBox(IEnumerable<Team> teams)
        {
            foreach (var team in teams)
            {
                // Proveri FIFA kod
                Debug.WriteLine($"Team: {team.Country}, FIFA Code: {team.Code}");

                cbTeams.Items.Add(team);
            }
        }
        private async Task<IList<Team>> FetchTeamsAsync(string endpoint)
       => await api.GetDataAsync<IList<Team>>(endpoint);


        private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ = HandleTeamSelectionAsync(sender);
        }

        private async Task HandleTeamSelectionAsync(object sender)
        {
            if (sender is not ComboBox comboBox || comboBox.SelectedItem is not Team chosenTeam)
                return;

            try
            {
                // Reset both panels before loading new data
                flpAllPlayers.Controls.Clear();
                flpFavoritePlayers.Controls.Clear();

                // Async loading of players for the selected team
                await LoadPanelWithPlayersAsync(chosenTeam.Country);

                // Persist selected team to user settings
                var countryName = chosenTeam.Country;
                repository.SetChosenTeamToSettings(countryName);
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentNullException)
            {
                // Log and display error message to user if there's an issue
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPanelWithPlayersAsync(string teamInput)
        {
            Debug.WriteLine($"Selected team: {teamInput}");
            try
            {
                // Reset 
                playerGoals.Clear();
                playerYellowCards.Clear();
                flpRankedByAttendance.Controls.Clear();

                string selectedCountry = teamInput;

                if (string.IsNullOrEmpty(selectedCountry)) return;

                flpAllPlayers.AutoScroll = true;
                flpAllPlayers.WrapContents = false;
                
                flpAllPlayers.FlowDirection = FlowDirection.TopDown;
                flpAllPlayers.HorizontalScroll.Enabled = false;
                flpAllPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                flpAllPlayers.AutoScrollMinSize = new Size(flpAllPlayers.Width, 1);
                // show loading indicator
                var loader = new BusyIndicator();
                loader.Show(flpAllPlayers);
                

                string genderStr = repository.GetStoredGender();

                if (!Enum.TryParse<GenderType>(genderStr, true, out var gender))
                {
                    MessageBox.Show("Invalid gender setting");
                    return;
                }
                string apiUrl = EndpointBuilder.BuildMatchesEndpoint(gender);
                var allMatches = await api.GetDataAsync<IList<MatchDetail>>(apiUrl);

                var relevantMatch = allMatches?.FirstOrDefault(m => m.HomeTeamCountry == selectedCountry || m.AwayTeamCountry == selectedCountry);
                var isHome = relevantMatch?.HomeTeamCountry == selectedCountry;
                var teamStats = isHome ? relevantMatch?.HomeTeamStatistics : relevantMatch?.AwayTeamStatistics;

                var allPlayers = teamStats?.StartingEleven?
                    .Concat(teamStats.Substitutes)
                    .ToList();

                if (teamStats == null || allPlayers == null || allPlayers.Count == 0)
                {
                    loader.Hide();
                    MessageBox.Show("No player data available for this team.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // load players
                flpAllPlayers.Controls.Clear();
                allPlayers?.ForEach(player =>
                {
                    var control = new PlayerUserControl
                    {
                        NameText = player.Name,
                        NumberText = player.ShirtNumber.ToString(),
                        PositionText = player.Position.ToString(),
                        CaptainText = player.Captain ? Resources.Resources.yes : Resources.Resources.no,
                        Name = player.Name
                    };

                    LoadPictureIfPreviouslySelected(control);

                    control.MouseDown += PlayerUserControl_MouseDown;
                    flpAllPlayers.Controls.Add(control);

                    playerGoals[player.Name] = 0;
                    playerYellowCards[player.Name] = 0;
                });

                // number of goals and cards
                var countryMatches = allMatches?
                    .Where(m => m.HomeTeamCountry == selectedCountry)
                    .ToList();

                foreach (var match in countryMatches ?? Enumerable.Empty<MatchDetail>())
                {
                    foreach (var evt in match.HomeTeamEvents)
                    {
                        if (!playerGoals.ContainsKey(evt.Player)) continue;

                        switch (evt.TypeOfEvent)
                        {
                            case TypeOfEvent.Goal:
                                playerGoals[evt.Player]++;
                                break;
                            case TypeOfEvent.YellowCard:
                            case TypeOfEvent.YellowCardSecond:
                                playerYellowCards[evt.Player]++;
                                break;
                        }
                    }
                }

                // rank matches by attendance
                var rankedMatches = allMatches?
                    .Where(m => m.HomeTeamCountry == selectedCountry || m.AwayTeamCountry == selectedCountry)
                    .OrderByDescending(m => m.Attendance)
                    .ToList();

                foreach (var match in rankedMatches ?? Enumerable.Empty<MatchDetail>())
                {
                    flpRankedByAttendance.Controls.Add(new MatchUserControl
                    {
                        MatchLocation = match.Location,
                        AttendanceText = match.Attendance.ToString(),
                        HomeTeamName = match.HomeTeamCountry,
                        AwayTeamName = match.AwayTeamCountry

                    });
                }

                // load favorite
                DisplayFavoritePlayers();
                loader.Hide();
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentNullException || ex is JsonReaderException)
            {
                MessageBox.Show(Resources.Resources.dataNotLoaded, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlayerUserControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is PlayerUserControl playerControl)
            {
                var clickedControl = (Control)sender;

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        playerControl.IsHighlighted = true;
                        draggableControls.Add(clickedControl);
                        EnableControlDrag(draggableControls);
                        break;

                    case MouseButtons.Middle:
                        playerControl.IsHighlighted = false;
                        draggableControls.Remove(clickedControl);
                        break;

                    case MouseButtons.Right:
                        var parentControl = clickedControl.Parent;
                        if (parentControl.Name == "flpAllPlayers")
                        {
                            ShowPlayerContextMenu(playerControl);
                        }
                        else
                        {
                            ShowFavoritePlayerContextMenu(playerControl);
                        }
                        contextMenuStrip.Show(clickedControl, new Point(e.X, e.Y));
                        break;
                }
            }
        }

        private void ShowFavoritePlayerContextMenu(PlayerUserControl playerControl)
        {
            contextMenuStrip.Items.Clear();

            var removeItem = new ToolStripMenuItem
            {
                Text = Resources.Resources.removeFavPlayer,
                Name = "removeFavoritePlayer"
            };
            removeItem.Click += (sender, e) =>
            {
                playerControl.IsStarDisplayed = false;
                flpAllPlayers.Controls.Add(playerControl);
                SaveCurrentFavoritePlayers();
            };

            contextMenuStrip.Items.Add(removeItem);
        }

        private void ShowPlayerContextMenu(PlayerUserControl playerControl)
        {
            contextMenuStrip.Items.Clear();

            var loadImageItem = new ToolStripMenuItem
            {
                Text = Resources.Resources.loadImage,
                Name = "loadImageItem"
            };
            loadImageItem.Click += (sender, e) => LoadImage(playerControl);
            contextMenuStrip.Items.Add(loadImageItem);

            var addToFavoritesItem = new ToolStripMenuItem
            {
                Text = Resources.Resources.favoritePlayer,
                Name = "favoritePlayerItem"
            };
            addToFavoritesItem.Click += (sender, e) =>
            {
                if (flpFavoritePlayers.Controls.Count >= 3) return;

                playerControl.IsStarDisplayed = true;
                playerControl.IsHighlighted = false;
                flpFavoritePlayers.Controls.Add(playerControl);
                SaveCurrentFavoritePlayers();
            };

            contextMenuStrip.Items.Add(addToFavoritesItem);
        }

        private void LoadImage(PlayerUserControl playerControl)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK && File.Exists(openFileDialog.FileName))
            {
                var path = openFileDialog.FileName.Trim();

                repository.MapPlayerToImage(playerControl.Name.Trim(), path);
                playerControl.PlayerPicture = Image.FromFile(path);
            }
        }

        private void SaveCurrentFavoritePlayers()
        => repository.SaveFavoritePlayers(flpFavoritePlayers.Controls
        .OfType<PlayerUserControl>()
        .Select(p => p.Name));

        private void EnableControlDrag(IEnumerable<Control> draggableControls) => draggableControls.ToList().ForEach(c => c.DoDragDrop(c.Name, DragDropEffects.Move));

        private void LoadPictureIfPreviouslySelected(PlayerUserControl playerControl)
        {
            string playerName = playerControl.Name;
            string picturePath = repository.RetrieveImagePath(playerName);

            if (repository.ImageExists(playerName) && File.Exists(picturePath))
            {
                playerControl.PlayerPicture = Image.FromFile(picturePath);
            }
        }

        private void WorldCup_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                Resources.Resources.formClosing,
                Resources.Resources.formClosingTitle,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question
                );

            e.Cancel = result == DialogResult.Cancel;
        }

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (flpFavoritePlayers.Controls.Count >= 3) return;

            if (e.Data.GetData(typeof(string)) is not string controlKey) return;
            if (Controls.Find(controlKey, true).FirstOrDefault() is not PlayerUserControl control) return;
            if (!control.IsHighlighted) return;

            if (control.Parent is Control parent)
            {
                parent.Controls.Remove(control);
            }

            flpFavoritePlayers.Controls.Add(control);
            control.IsHighlighted = false;
            control.IsStarDisplayed = true;

            var favoriteNames = flpFavoritePlayers.Controls
                .OfType<PlayerUserControl>()
                .Select(c => c.Name);

            repository.SaveFavoritePlayers(favoriteNames);
        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (flpFavoritePlayers.Controls.Count >= 3) return;

            if (e.Data.GetData(typeof(string)) is string controlKey &&
                Controls.Find(controlKey, true).FirstOrDefault() is PlayerUserControl control &&
                control.IsHighlighted)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            ClearRankingPanels();
        }

        private void ClearRankingPanels()
        {
            flpRankedByGoals.Controls.Clear();
            flpRankedByYellowCards.Controls.Clear();
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            PopulateRankingPanel(playerGoals, flpRankedByGoals, Resources.Resources.goals);
            PopulateRankingPanel(playerYellowCards, flpRankedByYellowCards, Resources.Resources.cards);
            SetUpScrollForPanels();
        }

        private void SetUpScrollForPanels()
        {
            
            flpRankedByGoals.AutoScroll = true;
            flpRankedByYellowCards.AutoScroll = true;
            flpRankedByAttendance.AutoScroll = true;

            
            flpRankedByGoals.HorizontalScroll.Enabled = false;
            flpRankedByYellowCards.HorizontalScroll.Enabled = false;
            flpRankedByAttendance.HorizontalScroll.Enabled = false;

            flpRankedByGoals.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpRankedByYellowCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpRankedByAttendance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void PopulateRankingPanel(IDictionary<string, int> playerGoals, FlowLayoutPanel panel, string goals)
        {
        playerGoals?
       .OrderByDescending(entry => entry.Value)
       .ToList()
       .ForEach(entry =>
       {
           var control = CreatePlayerStatControl(entry.Key, entry.Value, goals);
           panel.Controls.Add(control);
           LoadPictureIfPreviouslySelected(control);
       });
        }

        private PlayerUserControl CreatePlayerStatControl(string name, int value, string label)
        {
            return new PlayerUserControl
            {
                NameText = name,
                ExtraLabelText = label,
                ExtraValueText = value.ToString(),
                NumberText = value.ToString(),
                ShowPosition = false,
                ShowCaptain = false,
                Name = name
            };
        }
    }
}
