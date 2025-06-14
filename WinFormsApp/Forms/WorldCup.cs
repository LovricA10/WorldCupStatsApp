﻿using Dao.Api;
using Dao.Enums;
using Dao.Models;
using Dao.Repo;
using Dao.Utilitly;
using Newtonsoft.Json;
using Syncfusion.WinForms.Core.Utils;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
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

        private IApi api = ApiFactory.GetApi();
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
                    var result = settingsForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("Settings saved. Please restart the app manually to apply changes.", "Info");

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred while opening the settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void WorldCup_Activated(object sender, EventArgs e)
        {
            api = ApiFactory.GetApi();

            if (isFormFirstTimeShown)
            {
                try
                {
                    await LoadComboBoxWithTeamsAsync();

                    var selectedTeam = repository.GetCurrentTeam();
                    var availableTeams = cbTeams.Items.OfType<Team>().ToList();
                    var foundTeam = availableTeams.FirstOrDefault(t => t.Country == selectedTeam);

                    if (!string.IsNullOrWhiteSpace(selectedTeam) && foundTeam != null)
                    {
                        cbTeams.SelectedItem = foundTeam;
                        await LoadPanelWithPlayersAsync(selectedTeam);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to load selected team: {ex.Message}");
                    MessageBox.Show("An error occurred while loading the selected team. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    isFormFirstTimeShown = false;
                }
            }

            InitializeCulture();
        }

        private void DisplayFavoritePlayers()
        {
            try
            {
                var selectedTeam = cbTeams.SelectedItem as Team;
                if (selectedTeam == null) return;

                var teamCode = selectedTeam.Code;
                var teamFavorites = repository.GetFavoritePlayersList(teamCode)
                                              .ToHashSet(StringComparer.OrdinalIgnoreCase);

                foreach (PlayerUserControl playerControl in flpAllPlayers.Controls.OfType<PlayerUserControl>().ToList())
                {
                    if (teamFavorites.Contains(playerControl.Name.Trim()))
                    {
                        playerControl.IsStarDisplayed = true;
                        flpAllPlayers.Controls.Remove(playerControl);
                        flpFavoritePlayers.Controls.Add(playerControl);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading favorite players: {ex.Message}");
            }
        }

        private async Task LoadComboBoxWithTeamsAsync()
        {
            cbTeams.Items.Clear();
            cbTeams.Text = Resources.Resources.cbTeamsLoading;

            try
            {
                var teamGenderString = repository.GetStoredGender();
                var teamGender = Enum.TryParse(teamGenderString, out GenderType gender) ? gender : GenderType.Male;
                var endpoint = EndpointBuilder.BuildTeamsEndpoint(teamGender);

                var teams = await FetchTeamsAsync(endpoint);

                AddTeamsToComboBox(teams);

                cbTeams.Text = string.Empty;
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                ShowErrorNotification();
            }
        }

        private void ShowErrorNotification()
        =>
            MessageBox.Show(Resources.Resources.CouldNotRetrieveData, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void AddTeamsToComboBox(IEnumerable<Team> teams)
        {
            foreach (var team in teams)
            {
                // Check
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
                flpAllPlayers.Controls.Clear();
                flpFavoritePlayers.Controls.Clear();

                await LoadPanelWithPlayersAsync(chosenTeam.Country);
                var countryName = chosenTeam.Country;
                repository.SetChosenTeamToSettings(countryName);
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentNullException)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPanelWithPlayersAsync(string teamInput)
        {
            try
            {
                playerGoals.Clear();
                playerYellowCards.Clear();
                flpRankedByAttendance.Controls.Clear();

                string selectedCountry = teamInput;
                if (string.IsNullOrEmpty(selectedCountry)) return;

                flpAllPlayers.Controls.Clear();
                flpFavoritePlayers.Controls.Clear();

                flpAllPlayers.WrapContents = false;
                flpFavoritePlayers.WrapContents = false;
                flpAllPlayers.FlowDirection = FlowDirection.TopDown;
                flpFavoritePlayers.FlowDirection = FlowDirection.TopDown;
                flpAllPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                flpFavoritePlayers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                flpAllPlayers.AutoScrollMinSize = new Size(flpAllPlayers.Width, 1);

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
                var relevantMatch = allMatches?.FirstOrDefault(m =>
                    m.HomeTeamCountry == selectedCountry || m.AwayTeamCountry == selectedCountry);
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

                foreach (var player in allPlayers)
                {
                    var control = new PlayerUserControl
                    {
                        NameText = player.Name,
                        NumberText = player.ShirtNumber.ToString(),
                        PositionText = player.Position.ToString(),
                        CaptainText = player.Captain ? Resources.Resources.yes : Resources.Resources.no,
                        Name = player.Name.Trim()
                    };

                    LoadPictureIfPreviouslySelected(control);
                    control.MouseDown += PlayerUserControl_MouseDown;

                    if (!this.Controls.Contains(control))
                    {
                        this.Controls.Add(control);
                    }

                    flpAllPlayers.Controls.Add(control);

                    playerGoals[player.Name] = 0;
                    playerYellowCards[player.Name] = 0;
                }

                var countryMatches = allMatches?
                    .Where(m => m.HomeTeamCountry == selectedCountry || m.AwayTeamCountry == selectedCountry)
                    .ToList();

                foreach (var match in countryMatches ?? Enumerable.Empty<MatchDetail>())
                {
                    var events = match.HomeTeamCountry == selectedCountry ? match.HomeTeamEvents : match.AwayTeamEvents;

                    foreach (var evt in events)
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
                var selectedTeam = cbTeams.SelectedItem as Team;
                if (selectedTeam != null)
                {
                    SaveCurrentFavoritePlayers();
                }
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

                var selectedTeam = cbTeams.SelectedItem as Team;
                if (selectedTeam != null)
                {
                    SaveCurrentFavoritePlayers();
                }
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
        {
            var favoriteNames = flpFavoritePlayers.Controls
                                .OfType<PlayerUserControl>()
                                .Select(c => c.Name.Trim());

            var selectedTeam = cbTeams.SelectedItem as Team;
            if (selectedTeam != null)
            {
                repository.SaveFavoritePlayers(favoriteNames, selectedTeam.Code);
            }
        }

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

            var selectedTeam = cbTeams.SelectedItem as Team;
            if (selectedTeam != null)
            {
                repository.SaveFavoritePlayers(favoriteNames, selectedTeam.Code);
            }
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
        var panels = new[] 
            {
                flpRankedByGoals,
                flpRankedByYellowCards,
                flpRankedByAttendance,
                flpAllPlayers,
             };

            foreach (var panel in panels)
            {
                panel.AutoScroll = true;
                panel.FlowDirection = FlowDirection.TopDown;
                panel.WrapContents = false;
                panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }

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

        private void btnPrintGoals_Click(object sender, EventArgs e)
        {
            controlCounter = 0;
            ppdGoals.Document = pdGoals;
            ppdGoals.ShowDialog();
        }

        private void btnPrintCard_Click(object sender, EventArgs e)
        {
            controlCounter = 0;
            ppdCards.Document = pdCards;
            ppdCards.ShowDialog();
        }

        private void btnPrintAttendance_Click(object sender, EventArgs e)
        {
            controlCounter = 0;
            ppdAttendance.Document = pdAttendance;
            ppdAttendance.ShowDialog();
        }

        private void pdGoals_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintPanelControls(e, flpRankedByGoals);
        }

        private void pdCards_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintPanelControls(e, flpRankedByYellowCards);
        }

        private void pdAttendance_PrintPage(object sender,PrintPageEventArgs e)
        {
            PrintPanelControls(e, flpRankedByAttendance);
        }

        private void PrintPanelControls(PrintPageEventArgs e, FlowLayoutPanel panel)
        {
            const int startY = 25;
            const int x = 275;
            const int yIncrement = 150;
            var y = startY;

            for (var i = controlCounter; i < panel.Controls.Count; i++)
            {
                var control = panel.Controls[i];

                using var bitmap = new Bitmap(control.Width, control.Height);
                var rectangle = new Rectangle(0, 0, control.Width, control.Height);

                if (controlCounter % 7 != 0 || controlCounter == 0)
                {
                    control.DrawToBitmap(bitmap, rectangle);
                    e.Graphics.DrawImage(bitmap, new Point(x, y));

                    y += yIncrement;
                    controlCounter++;
                }
                else
                {
                    controlCounter++;
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
    }
}
