using Dao.Repo;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PlayerInformation.xaml
    /// </summary>
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
