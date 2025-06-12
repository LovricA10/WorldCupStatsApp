using System.ComponentModel;

namespace WinFormsApp.UserControls
{
    public partial class MatchUserControl : UserControl
    {

        [Category("Match Info")]
        public string MatchLocation
        {
            get => lblLocation.Text;
            set => lblLocation.Text = value.ToString();
        }

        [Category("Match Info")]
        public string AttendanceText
        {
            get => lblAttendance.Text;
            set => lblAttendance.Text = value.ToString();
        }

        [Category("Match Info")]
        public string HomeTeamName
        {
            get => lblHomeTeam.Text;
            set => lblHomeTeam.Text = value;
        }

        [Category("Match Info")]
        public string AwayTeamName
        {
            get => lblAwayTeam.Text;
            set => lblAwayTeam.Text = value;
        }
        public MatchUserControl()
        {
            InitializeComponent();
        }
    }
}
