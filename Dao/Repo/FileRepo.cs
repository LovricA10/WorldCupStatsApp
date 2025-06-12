namespace Dao.Repo
{
    internal class FileRepo : IRepository
    {
        private const string ConfigFile = @"user-settings.txt";
        private const string ImageMapFile = @"player-images.txt";
        private const string DefaultGender = @"female";
        private const string DefaultLanguage = @"EN";
        private const string BaseFolder = @"../../../assets";
        private const string WpfAppSize = @"wpf_app_size.txt";
        private static readonly string ConfigPath = Path.Combine(BaseFolder, ConfigFile);
        private static readonly string ImageMapPath = Path.Combine(BaseFolder, ImageMapFile);
        private static readonly string WpfAppSizePath = Path.Combine(BaseFolder, WpfAppSize);
        private const char Del = '|';


        public void SaveTournamentSettings(string category, string lang, string dataSource)
        {
            EnsureDirectoryExists();
            File.WriteAllText(ConfigPath, $"{category}{Del}{lang}{Del}{dataSource}");
        }

        public void SaveWindowSizeSetting(string size)
        {
            EnsureDirectoryExists();
            File.WriteAllText(WpfAppSizePath, size);
        }

        public void MapPlayerToImage(string player, string imagePath)
        {
            EnsureDirectoryExists();
            File.AppendAllText(ImageMapPath, $"{player}{Del}{imagePath}{Environment.NewLine}");
        }
        public void SetChosenTeamToSettings(string team)
        {
            if (!File.Exists(ConfigPath))
            {
                throw new Exception($"Settings file is missing: {ConfigFile}");
            }

            var gender = GetStoredGender();
            var lang = GetStoredLanguage();

            File.WriteAllText(ConfigPath, $"{gender}{Del}{lang}{Del}{team}");
        }

        public bool ImageExists(string playerControl)
        {
            try
            {
                if (!File.Exists(ImageMapPath))
                {
                    File.Create(ImageMapPath).Dispose();
                    return false;
                }
                return File.ReadAllLines(ImageMapPath)
                    .Any(line => line.Split(Del).FirstOrDefault() == playerControl);
            }
            catch
            {
                return false;
            }
        }

        public bool SettingsExists() => File.Exists(ConfigPath);

        public string LoadAllSettings()
        {
           return File.Exists(ConfigPath) ? File.ReadAllText(ConfigPath) : string.Empty;
        }

        public string RetrieveImagePath(string controlName)
        {
            if (!File.Exists(ImageMapPath)) return string.Empty;
            try
            {
                foreach (var line in File.ReadAllLines(ImageMapPath))
                {
                    if (line.Split(Del).FirstOrDefault() == controlName)
                    {
                        return line.Split(Del)[1];
                    }
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetStoredGender() => LoadAllSettings().Split(Del).FirstOrDefault() ?? DefaultGender;
        public string GetStoredLanguage() => LoadAllSettings().Split(Del).Skip(1).FirstOrDefault() ?? DefaultLanguage;

        public string GetCurrentTeam() => LoadAllSettings().Split(Del).Skip(2).FirstOrDefault() ?? string.Empty;

        public string GetSavedWindowSize()
        {
            try
            {
                if (!File.Exists(WpfAppSizePath))
                {
                    File.Create(WpfAppSizePath).Dispose();
                }
                return File.ReadAllText(WpfAppSizePath);
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SaveFavoritePlayers(IEnumerable<string> favoritePlayerNames, string teamCode)
        {
            EnsureDirectoryExists();
            var path = GetFavoriteFilePath(teamCode);
            File.WriteAllLines(path, favoritePlayerNames.Select(name => name.Trim()));
        }

        public IEnumerable<string> GetFavoritePlayersList(string teamCode)
        {
            var path = GetFavoriteFilePath(teamCode);
            if (!File.Exists(path))
            {
                return Enumerable.Empty<string>();
            }

            return File.ReadAllLines(path).Select(line => line.Trim());
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);

        }

        public string GetDataSource()
        {
            return LoadAllSettings().Split(Del).ElementAtOrDefault(2)?.ToUpper() ?? "API";
        }

        private static string GetFavoriteFilePath(string teamCode)
        {
            return Path.Combine(BaseFolder, $"favorite-players-{teamCode.ToUpper()}.txt");
        }

    }
}