namespace WinFormsApp.Forms
{
    partial class WorldCup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbTeams = new ComboBox();
            tabControl = new TabControl();
            tabPlayers = new TabPage();
            flpFavoritePlayers = new FlowLayoutPanel();
            flpAllPlayers = new FlowLayoutPanel();
            tabRankGoals = new TabPage();
            tabRankCards = new TabPage();
            tabRankAttendance = new TabPage();
            btnPrintGoals = new Button();
            flpRankedByGoals = new FlowLayoutPanel();
            btnPrintCard = new Button();
            flpRankedByYellowCards = new FlowLayoutPanel();
            btnPrintAttendance = new Button();
            flpRankByAttendance = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            tabControl.SuspendLayout();
            tabPlayers.SuspendLayout();
            tabRankGoals.SuspendLayout();
            tabRankCards.SuspendLayout();
            tabRankAttendance.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            cbTeams.Location = new Point(201, 49);
            cbTeams.Name = "cbTeams";
            cbTeams.Size = new Size(430, 28);
            cbTeams.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPlayers);
            tabControl.Controls.Add(tabRankGoals);
            tabControl.Controls.Add(tabRankCards);
            tabControl.Controls.Add(tabRankAttendance);
            tabControl.Location = new Point(12, 83);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(808, 508);
            tabControl.TabIndex = 1;
            tabControl.Tag = "RankCards";
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(flpAllPlayers);
            tabPlayers.Controls.Add(flpFavoritePlayers);
            tabPlayers.Location = new Point(4, 29);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Padding = new Padding(3);
            tabPlayers.Size = new Size(800, 475);
            tabPlayers.TabIndex = 0;
            tabPlayers.Tag = "players";
            tabPlayers.Text = "Players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // flpFavoritePlayers
            // 
            flpFavoritePlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flpFavoritePlayers.BackColor = Color.FromArgb(192, 255, 192);
            flpFavoritePlayers.Location = new Point(444, 6);
            flpFavoritePlayers.Name = "flpFavoritePlayers";
            flpFavoritePlayers.Size = new Size(350, 457);
            flpFavoritePlayers.TabIndex = 0;
            // 
            // flpAllPlayers
            // 
            flpAllPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flpAllPlayers.BackColor = Color.FromArgb(192, 255, 192);
            flpAllPlayers.Location = new Point(6, 6);
            flpAllPlayers.Name = "flpAllPlayers";
            flpAllPlayers.Size = new Size(350, 457);
            flpAllPlayers.TabIndex = 1;
            // 
            // tabRankGoals
            // 
            tabRankGoals.Controls.Add(flpRankedByGoals);
            tabRankGoals.Controls.Add(btnPrintGoals);
            tabRankGoals.Location = new Point(4, 29);
            tabRankGoals.Name = "tabRankGoals";
            tabRankGoals.Padding = new Padding(3);
            tabRankGoals.Size = new Size(800, 475);
            tabRankGoals.TabIndex = 1;
            tabRankGoals.Tag = "rankGoals";
            tabRankGoals.Text = "Rank by Goals";
            tabRankGoals.UseVisualStyleBackColor = true;
            // 
            // tabRankCards
            // 
            tabRankCards.Controls.Add(flpRankedByYellowCards);
            tabRankCards.Controls.Add(btnPrintCard);
            tabRankCards.Location = new Point(4, 29);
            tabRankCards.Name = "tabRankCards";
            tabRankCards.Padding = new Padding(3);
            tabRankCards.Size = new Size(800, 475);
            tabRankCards.TabIndex = 2;
            tabRankCards.Tag = "rankCards";
            tabRankCards.Text = "Rank by yellow cards";
            tabRankCards.UseVisualStyleBackColor = true;
            // 
            // tabRankAttendance
            // 
            tabRankAttendance.Controls.Add(flpRankByAttendance);
            tabRankAttendance.Controls.Add(btnPrintAttendance);
            tabRankAttendance.Location = new Point(4, 29);
            tabRankAttendance.Name = "tabRankAttendance";
            tabRankAttendance.Padding = new Padding(3);
            tabRankAttendance.Size = new Size(800, 475);
            tabRankAttendance.TabIndex = 3;
            tabRankAttendance.Tag = "RankAttendances";
            tabRankAttendance.Text = "Rank by attendances";
            tabRankAttendance.UseVisualStyleBackColor = true;
            // 
            // btnPrintGoals
            // 
            btnPrintGoals.Location = new Point(6, 211);
            btnPrintGoals.Name = "btnPrintGoals";
            btnPrintGoals.Size = new Size(173, 52);
            btnPrintGoals.TabIndex = 0;
            btnPrintGoals.Text = "PRINT";
            btnPrintGoals.UseVisualStyleBackColor = true;
            // 
            // flpRankedByGoals
            // 
            flpRankedByGoals.BackColor = Color.FromArgb(192, 255, 192);
            flpRankedByGoals.Location = new Point(185, 6);
            flpRankedByGoals.Name = "flpRankedByGoals";
            flpRankedByGoals.Size = new Size(430, 463);
            flpRankedByGoals.TabIndex = 1;
            // 
            // btnPrintCard
            // 
            btnPrintCard.Location = new Point(6, 211);
            btnPrintCard.Name = "btnPrintCard";
            btnPrintCard.Size = new Size(173, 52);
            btnPrintCard.TabIndex = 1;
            btnPrintCard.Text = "PRINT";
            btnPrintCard.UseVisualStyleBackColor = true;
            // 
            // flpRankedByYellowCards
            // 
            flpRankedByYellowCards.BackColor = Color.FromArgb(192, 255, 192);
            flpRankedByYellowCards.Location = new Point(185, 6);
            flpRankedByYellowCards.Name = "flpRankedByYellowCards";
            flpRankedByYellowCards.Size = new Size(430, 463);
            flpRankedByYellowCards.TabIndex = 2;
            // 
            // btnPrintAttendance
            // 
            btnPrintAttendance.Location = new Point(6, 211);
            btnPrintAttendance.Name = "btnPrintAttendance";
            btnPrintAttendance.Size = new Size(173, 52);
            btnPrintAttendance.TabIndex = 2;
            btnPrintAttendance.Text = "PRINT";
            btnPrintAttendance.UseVisualStyleBackColor = true;
            // 
            // flpRankByAttendance
            // 
            flpRankByAttendance.BackColor = Color.FromArgb(192, 255, 192);
            flpRankByAttendance.Location = new Point(185, 6);
            flpRankByAttendance.Name = "flpRankByAttendance";
            flpRankByAttendance.Size = new Size(430, 463);
            flpRankByAttendance.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(832, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // WorldCup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 603);
            Controls.Add(tabControl);
            Controls.Add(cbTeams);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "WorldCup";
            Text = "WorldCup";
            tabControl.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabRankGoals.ResumeLayout(false);
            tabRankCards.ResumeLayout(false);
            tabRankAttendance.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTeams;
        private TabControl tabControl;
        private TabPage tabPlayers;
        private TabPage tabRankGoals;
        private TabPage tabRankCards;
        private TabPage tabRankAttendance;
        private FlowLayoutPanel flpFavoritePlayers;
        private FlowLayoutPanel flpAllPlayers;
        private FlowLayoutPanel flpRankedByGoals;
        private Button btnPrintGoals;
        private FlowLayoutPanel flpRankedByYellowCards;
        private Button btnPrintCard;
        private FlowLayoutPanel flpRankByAttendance;
        private Button btnPrintAttendance;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}