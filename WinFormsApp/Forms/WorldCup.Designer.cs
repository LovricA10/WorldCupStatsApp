﻿namespace WinFormsApp.Forms
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
            cbTeams.FormattingEnabled = true;
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.Name = "cbTeams";
            cbTeams.SelectedIndexChanged += cbTeams_SelectedIndexChanged;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPlayers);
            tabControl.Controls.Add(tabRankGoals);
            tabControl.Controls.Add(tabRankCards);
            tabControl.Controls.Add(tabRankAttendance);
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Tag = "RankCards";
            tabControl.Selected += tabControl_Selected;
            tabControl.Deselecting += tabControl_Deselecting;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(flpAllPlayers);
            tabPlayers.Controls.Add(flpFavoritePlayers);
            resources.ApplyResources(tabPlayers, "tabPlayers");
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Tag = "players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // flpAllPlayers
            // 
            resources.ApplyResources(flpAllPlayers, "flpAllPlayers");
            flpAllPlayers.BackColor = Color.White;
            flpAllPlayers.Name = "flpAllPlayers";
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(flpFavoritePlayers, "flpFavoritePlayers");
            flpFavoritePlayers.BackColor = Color.White;
            flpFavoritePlayers.Name = "flpFavoritePlayers";
            flpFavoritePlayers.DragDrop += flpFavoritePlayers_DragDrop;
            flpFavoritePlayers.DragEnter += flpFavoritePlayers_DragEnter;
            // 
            // tabRankGoals
            // 
            tabRankGoals.Controls.Add(flpRankedByGoals);
            tabRankGoals.Controls.Add(btnPrintGoals);
            resources.ApplyResources(tabRankGoals, "tabRankGoals");
            tabRankGoals.Name = "tabRankGoals";
            tabRankGoals.Tag = "rankGoals";
            tabRankGoals.UseVisualStyleBackColor = true;
            // 
            // flpRankedByGoals
            // 
            flpRankedByGoals.BackColor = Color.White;
            resources.ApplyResources(flpRankedByGoals, "flpRankedByGoals");
            flpRankedByGoals.Name = "flpRankedByGoals";
            // 
            // btnPrintGoals
            // 
            btnPrintGoals.BackColor = Color.Black;
            btnPrintGoals.ForeColor = SystemColors.ButtonHighlight;
            resources.ApplyResources(btnPrintGoals, "btnPrintGoals");
            btnPrintGoals.Name = "btnPrintGoals";
            btnPrintGoals.UseVisualStyleBackColor = false;
            btnPrintGoals.Click += btnPrintGoals_Click;
            // 
            // tabRankCards
            // 
            tabRankCards.Controls.Add(flpRankedByYellowCards);
            tabRankCards.Controls.Add(btnPrintCard);
            resources.ApplyResources(tabRankCards, "tabRankCards");
            tabRankCards.Name = "tabRankCards";
            tabRankCards.Tag = "rankCards";
            tabRankCards.UseVisualStyleBackColor = true;
            // 
            // flpRankedByYellowCards
            // 
            flpRankedByYellowCards.BackColor = Color.White;
            resources.ApplyResources(flpRankedByYellowCards, "flpRankedByYellowCards");
            flpRankedByYellowCards.Name = "flpRankedByYellowCards";
            // 
            // btnPrintCard
            // 
            btnPrintCard.BackColor = Color.Black;
            btnPrintCard.ForeColor = SystemColors.ButtonHighlight;
            resources.ApplyResources(btnPrintCard, "btnPrintCard");
            btnPrintCard.Name = "btnPrintCard";
            btnPrintCard.UseVisualStyleBackColor = false;
            btnPrintCard.Click += btnPrintCard_Click;
            // 
            // tabRankAttendance
            // 
            tabRankAttendance.Controls.Add(flpRankedByAttendance);
            tabRankAttendance.Controls.Add(btnPrintAttendance);
            resources.ApplyResources(tabRankAttendance, "tabRankAttendance");
            tabRankAttendance.Name = "tabRankAttendance";
            tabRankAttendance.Tag = "RankAttendances";
            tabRankAttendance.UseVisualStyleBackColor = true;
            // 
            // flpRankedByAttendance
            // 
            flpRankedByAttendance.BackColor = Color.White;
            resources.ApplyResources(flpRankedByAttendance, "flpRankedByAttendance");
            flpRankedByAttendance.Name = "flpRankedByAttendance";
            // 
            // btnPrintAttendance
            // 
            btnPrintAttendance.BackColor = Color.Black;
            btnPrintAttendance.ForeColor = SystemColors.ButtonHighlight;
            resources.ApplyResources(btnPrintAttendance, "btnPrintAttendance");
            btnPrintAttendance.Name = "btnPrintAttendance";
            btnPrintAttendance.UseVisualStyleBackColor = false;
            btnPrintAttendance.Click += btnPrintAttendance_Click;
            // 
            // menuStripWorldCup
            // 
            menuStripWorldCup.ImageScalingSize = new Size(20, 20);
            menuStripWorldCup.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            resources.ApplyResources(menuStripWorldCup, "menuStripWorldCup");
            menuStripWorldCup.Name = "menuStripWorldCup";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // ppdGoals
            // 
            resources.ApplyResources(ppdGoals, "ppdGoals");
            ppdGoals.Name = "ppdGoals";
            // 
            // pdGoals
            // 
            pdGoals.PrintPage += pdGoals_PrintPage;
            // 
            // pdCards
            // 
            pdCards.PrintPage += pdCards_PrintPage;
            // 
            // ppdCards
            // 
            resources.ApplyResources(ppdCards, "ppdCards");
            ppdCards.Name = "ppdCards";
            // 
            // pdAttendance
            // 
            pdAttendance.PrintPage += pdAttendance_PrintPage;
            // 
            // ppdAttendance
            // 
            resources.ApplyResources(ppdAttendance, "ppdAttendance");
            ppdAttendance.Name = "ppdAttendance";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(contextMenuStrip, "contextMenuStrip");
            // 
            // WorldCup
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl);
            Controls.Add(cbTeams);
            Controls.Add(menuStripWorldCup);
            MainMenuStrip = menuStripWorldCup;
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