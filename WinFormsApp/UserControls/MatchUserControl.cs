using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.UserControls
{
    public partial class MatchUserControl : UserControl
    {

        [Category("Match Info")]
        public string MatchLocation
        {
            get => lblLocation.Text;
            set => lblLocation.Text = $"Location: {value}";
        }

        [Category("Match Info")]
        public string AttendanceText
        {
            get => lblAttendance.Text;
            set => lblAttendance.Text = $"Attendance: {value}";
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
