namespace WinFormsApp.UserControls
{
    partial class MatchUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchUserControl));
            lbLocation = new Label();
            lbAttendance = new Label();
            lbHomeTeam = new Label();
            lbAwayTeam = new Label();
            lblLocation = new Label();
            lblAttendance = new Label();
            lblHomeTeam = new Label();
            lblAwayTeam = new Label();
            SuspendLayout();
            // 
            // lbLocation
            // 
            resources.ApplyResources(lbLocation, "lbLocation");
            lbLocation.Name = "lbLocation";
            // 
            // lbAttendance
            // 
            resources.ApplyResources(lbAttendance, "lbAttendance");
            lbAttendance.Name = "lbAttendance";
            // 
            // lbHomeTeam
            // 
            resources.ApplyResources(lbHomeTeam, "lbHomeTeam");
            lbHomeTeam.Name = "lbHomeTeam";
            // 
            // lbAwayTeam
            // 
            resources.ApplyResources(lbAwayTeam, "lbAwayTeam");
            lbAwayTeam.Name = "lbAwayTeam";
            // 
            // lblLocation
            // 
            resources.ApplyResources(lblLocation, "lblLocation");
            lblLocation.Name = "lblLocation";
            // 
            // lblAttendance
            // 
            resources.ApplyResources(lblAttendance, "lblAttendance");
            lblAttendance.Name = "lblAttendance";
            // 
            // lblHomeTeam
            // 
            resources.ApplyResources(lblHomeTeam, "lblHomeTeam");
            lblHomeTeam.Name = "lblHomeTeam";
            // 
            // lblAwayTeam
            // 
            resources.ApplyResources(lblAwayTeam, "lblAwayTeam");
            lblAwayTeam.Name = "lblAwayTeam";
            // 
            // MatchUserControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAwayTeam);
            Controls.Add(lblHomeTeam);
            Controls.Add(lblAttendance);
            Controls.Add(lblLocation);
            Controls.Add(lbAwayTeam);
            Controls.Add(lbHomeTeam);
            Controls.Add(lbAttendance);
            Controls.Add(lbLocation);
            Name = "MatchUserControl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbLocation;
        private Label lbAttendance;
        private Label lbHomeTeam;
        private Label lbAwayTeam;
        private Label lblLocation;
        private Label lblAttendance;
        private Label lblHomeTeam;
        private Label lblAwayTeam;
    }
}
