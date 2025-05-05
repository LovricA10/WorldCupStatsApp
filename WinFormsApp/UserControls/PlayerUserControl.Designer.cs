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
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            SuspendLayout();
            // 
            // pbPlayer
            // 
            pbPlayer.Image = (Image)resources.GetObject("pbPlayer.Image");
            pbPlayer.Location = new Point(3, 3);
            pbPlayer.Name = "pbPlayer";
            pbPlayer.Size = new Size(158, 153);
            pbPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            //pbPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbPlayer.TabIndex = 0;
            pbPlayer.TabStop = false;
            
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(167, 22);
            lbName.Name = "lbName";
            lbName.Size = new Size(52, 20);
            lbName.TabIndex = 1;
            lbName.Text = "Name:";
            // 
            // lbNumber
            // 
            lbNumber.AutoSize = true;
            lbNumber.Location = new Point(167, 55);
            lbNumber.Name = "lbNumber";
            lbNumber.Size = new Size(66, 20);
            lbNumber.TabIndex = 2;
            lbNumber.Text = "Number:";
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Location = new Point(167, 88);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(61, 20);
            lbPosition.TabIndex = 3;
            lbPosition.Text = "Position";
            // 
            // lbCaptain
            // 
            lbCaptain.AutoSize = true;
            lbCaptain.Location = new Point(167, 122);
            lbCaptain.Name = "lbCaptain";
            lbCaptain.Size = new Size(60, 20);
            lbCaptain.TabIndex = 4;
            lbCaptain.Text = "Captain";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(225, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 20);
            lblName.TabIndex = 5;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(233, 55);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(0, 20);
            lblNumber.TabIndex = 6;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(233, 88);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(0, 20);
            lblPosition.TabIndex = 7;
            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.Location = new Point(228, 122);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(0, 20);
            lblCaptain.TabIndex = 8;
            // 
            // lblStar
            // 
            lblStar.AutoSize = true;
            lblStar.Location = new Point(328, 3);
            lblStar.Name = "lblStar";
            lblStar.Size = new Size(0, 20);
            lblStar.TabIndex = 9;
            // 
            // PlayerUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
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
            Name = "PlayerUserControl";
            Size = new Size(373, 159);
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
    }
}
