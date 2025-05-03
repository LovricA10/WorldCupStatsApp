using Dao.Repo;
using WinFormsApp.Forms;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var repository = RepositoryFactory.GetRepository();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(repository.SettingsExists() ? new WorldCup() : new Settings());
            Application.Run(new Settings());
        }
    }
}