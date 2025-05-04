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
    public partial class PlayerUserControl : UserControl
    {

        #region Properties

        private string playerName;
        [Category("Player")]
        public string NameText
        {
            get => playerName;
            set
            {
                playerName = value;
                lbName.Text = value;
            }
        }

        private string playerNumber;
        [Category("Player")]
        public string NumberText
        {
            get => playerNumber;
            set
            {
                playerNumber = value;
                lbNumber.Text = value;
            }
        }

        private string position;
        [Category("Player")]
        public string PositionText
        {
            get => position;
            set
            {
                position = value;
                lbPosition.Text = value;
            }
        }

        private string captain;
        [Category("Player")]
        public string CaptainText
        {
            get => captain;
            set
            {
                captain = value;
                lbCaptain.Text = value;
            }
        }

        private Image playerImage;
        [Category("Player")]
        public Image PlayerPicture
        {
            get => playerImage;
            set
            {
                playerImage = value;
                pbPlayer.Image = value;
                pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private bool isSelected;
        [Category("Player")]
        public bool IsHighlighted
        {
            get => isSelected;
            set
            {
                isSelected = value;
                BackColor = value ? Color.LightBlue : SystemColors.Control;
            }
        }

        private bool showPosition;
        [Category("Player")]
        public bool ShowPosition
        {
            get => showPosition;
            set
            {
                showPosition = value;
                lbPosition.Visible = value;
            }
        }

        private bool showCaptain;
        [Category("Player")]
        public bool ShowCaptain
        {
            get => showCaptain;
            set
            {
                showCaptain = value;
                lbCaptain.Visible = value;
            }
        }

        private string labelOverride;
        [Category("Player")]
        public string ExtraLabelText
        {
            get => labelOverride;
            set
            {
                labelOverride = value;
                lbNumber.Text = value;
            }
        }

        private bool showStar;

        [Category("Player")]
        public bool IsStarDisplayed
        {
            get => showStar;
            set
            {
                showStar = value;
                if (value)
                {
                    lblStar.Visible = true;
                    lblStar.Text = "★";
                    lblStar.ForeColor = Color.Gold;
                    lblStar.Font = new Font("Segoe UI", 28, FontStyle.Bold);
                }
                else
                {
                    lblStar.Visible = false;
                }
            }
        }

        #endregion

        public PlayerUserControl()
        {
            InitializeComponent();
        }
    }
}
