using Dao.Repo;
using System.Windows;

namespace WpfApp.Forms
{
    public partial class PlayerInformation : Window
    {
        private readonly IRepository repository;
        private const string DefaultImagePath = @"../../ImageSource/player.png";

        public string PlayerImagePath { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public string ShirtNumber { get; set; }
        public string Captain { get; set; }
        public string GoalsScored { get; set; }
        public string YellowCardsReceived { get; set; }
        public PlayerInformation(string playerName, string position, string shirtNumber, string captain, string goalsScored, string yellowCardsReceived)
        {
            InitializeComponent();

            repository = RepositoryFactory.GetRepository();
            PlayerName = playerName;
            Position = position;
            ShirtNumber = shirtNumber;
            Captain = captain;
            GoalsScored = goalsScored;
            YellowCardsReceived = yellowCardsReceived;

            PlayerImagePath = repository.ImageExists(PlayerName) 
            ? repository.RetrieveImagePath(PlayerName) : DefaultImagePath;

            DataContext = this;
        }
    }
}
