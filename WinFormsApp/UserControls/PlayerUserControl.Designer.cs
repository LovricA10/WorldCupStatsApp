namespace WinFormsApp.UserControls
{
    partial class PlayerUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUserControl));
            pbPlayer = new PictureBox();
            lbName = new Label();
            lbNumber = new Label();
            lbPosition = new Label();
            lbCaptain = new Label();
            lblName = new Label();
            lblNumber = new Label();
            lblPosition = new Label();
            lblCaptain = new Label();
            lblStar = new Label();
            lbExtra = new Label();
            lblExtraValue = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            SuspendLayout();
            // 
            // pbPlayer
            // 
            resources.ApplyResources(pbPlayer, "pbPlayer");
            pbPlayer.Name = "pbPlayer";
            pbPlayer.TabStop = false;
            // 
            // lbName
            // 
            resources.ApplyResources(lbName, "lbName");
            lbName.Name = "lbName";
            // 
            // lbNumber
            // 
            resources.ApplyResources(lbNumber, "lbNumber");
            lbNumber.Name = "lbNumber";
            // 
            // lbPosition
            // 
            resources.ApplyResources(lbPosition, "lbPosition");
            lbPosition.Name = "lbPosition";
            // 
            // lbCaptain
            // 
            resources.ApplyResources(lbCaptain, "lbCaptain");
            lbCaptain.Name = "lbCaptain";
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // lblNumber
            // 
            resources.ApplyResources(lblNumber, "lblNumber");
            lblNumber.Name = "lblNumber";
            // 
            // lblPosition
            // 
            resources.ApplyResources(lblPosition, "lblPosition");
            lblPosition.Name = "lblPosition";
            // 
            // lblCaptain
            // 
            resources.ApplyResources(lblCaptain, "lblCaptain");
            lblCaptain.Name = "lblCaptain";
            // 
            // lblStar
            // 
            resources.ApplyResources(lblStar, "lblStar");
            lblStar.Name = "lblStar";
            // 
            // lbExtra
            // 
            resources.ApplyResources(lbExtra, "lbExtra");
            lbExtra.Name = "lbExtra";
            // 
            // lblExtraValue
            // 
            resources.ApplyResources(lblExtraValue, "lblExtraValue");
            lblExtraValue.Name = "lblExtraValue";
            // 
            // PlayerUserControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStar);
            Controls.Add(lblCaptain);
            Controls.Add(lblPosition);
            Controls.Add(lblNumber);
            Controls.Add(lblName);
            Controls.Add(lbCaptain);
            Controls.Add(lbPosition);
            Controls.Add(lbNumber);
            Controls.Add(lbName);
            Controls.Add(pbPlayer);
            Controls.Add(lbExtra);
            Controls.Add(lblExtraValue);
            Name = "PlayerUserControl";
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPlayer;
        private Label lbName;
        private Label lbNumber;
        private Label lbPosition;
        private Label lbCaptain;
        private Label lblName;
        private Label lblNumber;
        private Label lblPosition;
        private Label lblCaptain;
        private Label lblStar;
        private Label lbExtra;
        private Label lblExtraValue;
    }
}
