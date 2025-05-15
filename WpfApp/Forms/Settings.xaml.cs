using Dao.Repo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp.Forms
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
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
            const string title = "Settings";
            const string message = "Confirm selected language and tournament type.";

            var confirmed = MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (confirmed != MessageBoxResult.OK) return;

            try
            {
                var selectedTournament = GetCheckedTag(PnlTournamentType);
                var selectedLanguage = GetCheckedTag(PnlLanguage);
                var selectedWindowSize = GetCheckedTag(PnlAppSize);

                repository.SaveTournamentSettings(selectedTournament, selectedLanguage);
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

