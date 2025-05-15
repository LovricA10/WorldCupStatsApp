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
    /// Interaction logic for TeamInformation.xaml
    /// </summary>
    public partial class TeamInformation : Window
    {

        public string TeamName { get; set; }
        public string FifaCode { get; set; }
        public string MatchesWon { get; set; }
        public string MatchesDraw { get; set; }
        public string MatchesLost { get; set; }
        public string MatchesPlayed { get; set; }
        public string GoalsScored { get; set; }
        public string GoalsReceived { get; set; }

        public TeamInformation(
            string teamName, string fifaCode, string matchesWon, string matchesDraw,
            string matchesLost, string matchesPlayed, string goalsScored, string goalsReceived)
        {
            InitializeComponent();
            TeamName = teamName;
            FifaCode = fifaCode;
            MatchesWon = matchesWon;
            MatchesDraw = matchesDraw;
            MatchesLost = matchesLost;
            MatchesPlayed = matchesPlayed;
            GoalsScored = goalsScored;
            GoalsReceived = goalsReceived;

            DataContext = this;
        }
    }
}
