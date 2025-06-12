using Dao.Repo;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Forms
{
    public partial class Settings : Window
    {
        private readonly IRepository repository;
        public Settings()
        {
            repository = RepositoryFactory.GetRepository();
            ApplyStoredCulture();
            InitializeComponent();
        }

        private void ApplyStoredCulture()
        {
            var language = repository.GetStoredLanguage();

            if (!string.IsNullOrWhiteSpace(language))
            {
                try
                {
                    var culture = new CultureInfo(language);
                    Thread.CurrentThread.CurrentUICulture = culture;
                    Thread.CurrentThread.CurrentCulture = culture;
                }
                catch (CultureNotFoundException)
                {

                    // fallback to default lang
                }
            }
        }

        private void btnSettingsSave_OnClick(object sender, RoutedEventArgs e)
        {
            string title =   Properties.Resources.settingsTitle;
            string message = Properties.Resources.message;

            var confirmed = MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (confirmed != MessageBoxResult.OK) return;

            try
            {
                var selectedTournament = GetCheckedTag(PnlTournamentType);
                var selectedLanguage = GetCheckedTag(PnlLanguage);
                var selectedWindowSize = GetCheckedTag(PnlAppSize);
                var selectedDataSource = GetCheckedTag(PnlDataSource);

                repository.SaveTournamentSettings(selectedTournament, selectedLanguage, selectedDataSource);
                repository.SaveWindowSizeSetting(selectedWindowSize);

                OpenMainWindow();
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is IOException || ex is CultureNotFoundException)
            {
                MessageBox.Show("An unexpected error occurred while saving settings.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenMainWindow()
        {
            Hide();
            var mainForm = new WorldCup();
            mainForm.ShowDialog();
            Close();
        }

        private string GetCheckedTag(Panel panel)
       => panel.Children.OfType<RadioButton>()
                        .FirstOrDefault(rb => rb.IsChecked == true)
                        ?.Tag?.ToString() ?? throw new ArgumentNullException("No option selected in panel.");
    }
}

