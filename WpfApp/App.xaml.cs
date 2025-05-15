using Dao.Repo;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IRepository? repository;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            InitializeRepository();
            SetStartupWindow();
        }

        private void InitializeRepository()
        {
            repository = RepositoryFactory.GetRepository();
        }

        private void SetStartupWindow()
        {
            string initialForm = repository.SettingsExists() ? "WorldCup.xaml" : "Settings.xaml";
            StartupUri = new Uri($"Forms/{initialForm}", UriKind.Relative);
        }
    }

}
