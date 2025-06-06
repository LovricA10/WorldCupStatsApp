using Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dao.Repo
{
    public interface IRepository
    {
        void SaveTournamentSettings(string tournamentCategory,  string language, string dataSource);
        void SaveWindowSizeSetting(string windowSize);

        // Method to save a player's picture path
        void MapPlayerToImage(string player, string picturePath);
        void SetChosenTeamToSettings(string team);

        // Method to check if a picture exists for a player
        bool ImageExists(string playerControl);
        bool SettingsExists();

        // Method to load all settings as a single string
        string LoadAllSettings();
        string RetrieveImagePath(string controlName);
        string GetStoredGender();
        string GetStoredLanguage();
        string GetCurrentTeam();

        // Method to get the app's size setting
        string GetSavedWindowSize();
        void SaveFavoritePlayers(IEnumerable<string> favoritePlayerNames);
        IEnumerable<string> GetFavoritePlayersList();
    }
}
