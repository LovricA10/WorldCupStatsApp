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
            lbLocation.AutoSize = true;
            lbLocation.Location = new Point(47, 29);
            lbLocation.Name = "lbLocation";
            lbLocation.Size = new Size(69, 20);
            lbLocation.TabIndex = 0;
            lbLocation.Text = "Location:";
            // 
            // lbAttendance
            // 
            lbAttendance.AutoSize = true;
            lbAttendance.Location = new Point(47, 66);
            lbAttendance.Name = "lbAttendance";
            lbAttendance.Size = new Size(88, 20);
            lbAttendance.TabIndex = 1;
            lbAttendance.Text = "Attendance:";
            // 
            // lbHomeTeam
            // 
            lbHomeTeam.AutoSize = true;
            lbHomeTeam.Location = new Point(47, 101);
            lbHomeTeam.Name = "lbHomeTeam";
            lbHomeTeam.Size = new Size(91, 20);
            lbHomeTeam.TabIndex = 2;
            lbHomeTeam.Text = "Home team:";
            // 
            // lbAwayTeam
            // 
            lbAwayTeam.AutoSize = true;
            lbAwayTeam.Location = new Point(47, 138);
            lbAwayTeam.Name = "lbAwayTeam";
            lbAwayTeam.Size = new Size(86, 20);
            lbAwayTeam.TabIndex = 3;
            lbAwayTeam.Text = "Away team:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(144, 29);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 4;
            // 
            // lblAttendance
            // 
            lblAttendance.AutoSize = true;
            lblAttendance.Location = new Point(144, 66);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(0, 20);
            lblAttendance.TabIndex = 5;
            // 
            // lblHomeTeam
            // 
            lblHomeTeam.AutoSize = true;
            lblHomeTeam.Location = new Point(144, 101);
            lblHomeTeam.Name = "lblHomeTeam";
            lblHomeTeam.Size = new Size(0, 20);
            lblHomeTeam.TabIndex = 6;
            // 
            // lblAwayTeam
            // 
            lblAwayTeam.AutoSize = true;
            lblAwayTeam.Location = new Point(144, 138);
            lblAwayTeam.Name = "lblAwayTeam";
            lblAwayTeam.Size = new Size(0, 20);
            lblAwayTeam.TabIndex = 7;
            // 
            // MatchUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
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
            Size = new Size(386, 175);
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
