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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldCup));
            cbTeams = new ComboBox();
            tabControl = new TabControl();
            tabPlayers = new TabPage();
            flpAllPlayers = new FlowLayoutPanel();
            flpFavoritePlayers = new FlowLayoutPanel();
            tabRankGoals = new TabPage();
            flpRankedByGoals = new FlowLayoutPanel();
            btnPrintGoals = new Button();
            tabRankCards = new TabPage();
            flpRankedByYellowCards = new FlowLayoutPanel();
            btnPrintCard = new Button();
            tabRankAttendance = new TabPage();
            flpRankedByAttendance = new FlowLayoutPanel();
            btnPrintAttendance = new Button();
            menuStripWorldCup = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            ppdGoals = new PrintPreviewDialog();
            pdGoals = new System.Drawing.Printing.PrintDocument();
            pdCards = new System.Drawing.Printing.PrintDocument();
            ppdCards = new PrintPreviewDialog();
            pdAttendance = new System.Drawing.Printing.PrintDocument();
            ppdAttendance = new PrintPreviewDialog();
            contextMenuStrip = new ContextMenuStrip(components);
            tabControl.SuspendLayout();
            tabPlayers.SuspendLayout();
            tabRankGoals.SuspendLayout();
            tabRankCards.SuspendLayout();
            tabRankAttendance.SuspendLayout();
            menuStripWorldCup.SuspendLayout();
            SuspendLayout();
            // 
            // cbTeams
            // 
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.FormattingEnabled = true;
            cbTeams.Name = "cbTeams";
            cbTeams.SelectedIndexChanged += cbTeams_SelectedIndexChanged;
            // 
            // tabControl
            // 
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.Controls.Add(tabPlayers);
            tabControl.Controls.Add(tabRankGoals);
            tabControl.Controls.Add(tabRankCards);
            tabControl.Controls.Add(tabRankAttendance);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Tag = "RankCards";
            tabControl.Selected += tabControl_Selected;
            tabControl.Deselecting += tabControl_Deselecting;
            // 
            // tabPlayers
            // 
            resources.ApplyResources(tabPlayers, "tabPlayers");
            tabPlayers.Controls.Add(flpAllPlayers);
            tabPlayers.Controls.Add(flpFavoritePlayers);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Tag = "players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // flpAllPlayers
            // 
            resources.ApplyResources(flpAllPlayers, "flpAllPlayers");
            flpAllPlayers.BackColor = Color.FromArgb(192, 255, 192);
            flpAllPlayers.Name = "flpAllPlayers";
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(flpFavoritePlayers, "flpFavoritePlayers");
            flpFavoritePlayers.BackColor = Color.FromArgb(192, 255, 192);
            flpFavoritePlayers.Name = "flpFavoritePlayers";
            flpFavoritePlayers.DragDrop += flpFavoritePlayers_DragDrop;
            flpFavoritePlayers.DragEnter += flpFavoritePlayers_DragEnter;
            // 
            // tabRankGoals
            // 
            resources.ApplyResources(tabRankGoals, "tabRankGoals");
            tabRankGoals.Controls.Add(flpRankedByGoals);
            tabRankGoals.Controls.Add(btnPrintGoals);
            tabRankGoals.Name = "tabRankGoals";
            tabRankGoals.Tag = "rankGoals";
            tabRankGoals.UseVisualStyleBackColor = true;
            // 
            // flpRankedByGoals
            // 
            resources.ApplyResources(flpRankedByGoals, "flpRankedByGoals");
            flpRankedByGoals.BackColor = Color.FromArgb(192, 255, 192);
            flpRankedByGoals.Name = "flpRankedByGoals";
            // 
            // btnPrintGoals
            // 
            resources.ApplyResources(btnPrintGoals, "btnPrintGoals");
            btnPrintGoals.Name = "btnPrintGoals";
            btnPrintGoals.UseVisualStyleBackColor = true;
            // 
            // tabRankCards
            // 
            resources.ApplyResources(tabRankCards, "tabRankCards");
            tabRankCards.Controls.Add(flpRankedByYellowCards);
            tabRankCards.Controls.Add(btnPrintCard);
            tabRankCards.Name = "tabRankCards";
            tabRankCards.Tag = "rankCards";
            tabRankCards.UseVisualStyleBackColor = true;
            // 
            // flpRankedByYellowCards
            // 
            resources.ApplyResources(flpRankedByYellowCards, "flpRankedByYellowCards");
            flpRankedByYellowCards.BackColor = Color.FromArgb(192, 255, 192);
            flpRankedByYellowCards.Name = "flpRankedByYellowCards";
            // 
            // btnPrintCard
            // 
            resources.ApplyResources(btnPrintCard, "btnPrintCard");
            btnPrintCard.Name = "btnPrintCard";
            btnPrintCard.UseVisualStyleBackColor = true;
            // 
            // tabRankAttendance
            // 
            resources.ApplyResources(tabRankAttendance, "tabRankAttendance");
            tabRankAttendance.Controls.Add(flpRankedByAttendance);
            tabRankAttendance.Controls.Add(btnPrintAttendance);
            tabRankAttendance.Name = "tabRankAttendance";
            tabRankAttendance.Tag = "RankAttendances";
            tabRankAttendance.UseVisualStyleBackColor = true;
            // 
            // flpRankedByAttendance
            // 
            resources.ApplyResources(flpRankedByAttendance, "flpRankedByAttendance");
            flpRankedByAttendance.BackColor = Color.FromArgb(192, 255, 192);
            flpRankedByAttendance.Name = "flpRankedByAttendance";
            // 
            // btnPrintAttendance
            // 
            resources.ApplyResources(btnPrintAttendance, "btnPrintAttendance");
            btnPrintAttendance.Name = "btnPrintAttendance";
            btnPrintAttendance.UseVisualStyleBackColor = true;
            // 
            // menuStripWorldCup
            // 
            resources.ApplyResources(menuStripWorldCup, "menuStripWorldCup");
            menuStripWorldCup.ImageScalingSize = new Size(20, 20);
            menuStripWorldCup.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStripWorldCup.Name = "menuStripWorldCup";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // ppdGoals
            // 
            resources.ApplyResources(ppdGoals, "ppdGoals");
            ppdGoals.Name = "ppdGoals";
            // 
            // ppdCards
            // 
            resources.ApplyResources(ppdCards, "ppdCards");
            ppdCards.Name = "ppdCards";
            // 
            // ppdAttendance
            // 
            resources.ApplyResources(ppdAttendance, "ppdAttendance");
            ppdAttendance.Name = "ppdAttendance";
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(contextMenuStrip, "contextMenuStrip");
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Name = "contextMenuStrip";
            // 
            // WorldCup
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl);
            Controls.Add(cbTeams);
            Controls.Add(menuStripWorldCup);
            Name = "WorldCup";
            Activated += WorldCup_Activated;
            FormClosing += WorldCup_FormClosing;
            tabControl.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabRankGoals.ResumeLayout(false);
            tabRankCards.ResumeLayout(false);
            tabRankAttendance.ResumeLayout(false);
            menuStripWorldCup.ResumeLayout(false);
            menuStripWorldCup.PerformLayout();
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
        private FlowLayoutPanel flpRankedByAttendance;
        private Button btnPrintAttendance;
        private MenuStrip menuStripWorldCup;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private PrintPreviewDialog ppdGoals;
        private System.Drawing.Printing.PrintDocument pdGoals;
        private System.Drawing.Printing.PrintDocument pdCards;
        private PrintPreviewDialog ppdCards;
        private System.Drawing.Printing.PrintDocument pdAttendance;
        private PrintPreviewDialog ppdAttendance;
        private ContextMenuStrip contextMenuStrip;
    }
}