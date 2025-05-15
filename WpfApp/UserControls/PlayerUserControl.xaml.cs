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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerUserControl.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {

        private readonly IRepository repository;
        //private const string DefaultImagePath = @"../../ImageSource/player.png";
        private const string DefaultImagePath = @"pack://application:,,,/ImageSource/player.png";

        public string PlayerName { get; set; }
        public string ShirtNumber { get; set; }

        public string PlayerImagePath { get; private set; }
       
        public PlayerUserControl(string playerName, string shirtNumber)
        {
            InitializeComponent();
            repository = RepositoryFactory.GetRepository();
            PlayerName = playerName;
            ShirtNumber = shirtNumber;

            PlayerImagePath = repository.ImageExists(PlayerName)
               ? repository.RetrieveImagePath(PlayerName)
               : DefaultImagePath;


            DataContext = this;
        }

    }
}
