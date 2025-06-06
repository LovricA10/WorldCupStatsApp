namespace WinFormsApp.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            gbGenderSelection = new GroupBox();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            gbLanguage = new GroupBox();
            rbEnglish = new RadioButton();
            rbCroatian = new RadioButton();
            btnSubmit = new Button();
            gbSource = new GroupBox();
            rbApi = new RadioButton();
            rbJson = new RadioButton();
            gbGenderSelection.SuspendLayout();
            gbLanguage.SuspendLayout();
            gbSource.SuspendLayout();
            SuspendLayout();
            // 
            // gbGenderSelection
            // 
            gbGenderSelection.Controls.Add(rbFemale);
            gbGenderSelection.Controls.Add(rbMale);
            resources.ApplyResources(gbGenderSelection, "gbGenderSelection");
            gbGenderSelection.Name = "gbGenderSelection";
            gbGenderSelection.TabStop = false;
            // 
            // rbFemale
            // 
            resources.ApplyResources(rbFemale, "rbFemale");
            rbFemale.Name = "rbFemale";
            rbFemale.Tag = "female";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            rbMale.Checked = true;
            resources.ApplyResources(rbMale, "rbMale");
            rbMale.Name = "rbMale";
            rbMale.TabStop = true;
            rbMale.Tag = "male";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbEnglish);
            gbLanguage.Controls.Add(rbCroatian);
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Name = "gbLanguage";
            gbLanguage.TabStop = false;
            // 
            // rbEnglish
            // 
            rbEnglish.Checked = true;
            resources.ApplyResources(rbEnglish, "rbEnglish");
            rbEnglish.Name = "rbEnglish";
            rbEnglish.TabStop = true;
            rbEnglish.Tag = "EN";
            rbEnglish.UseVisualStyleBackColor = true;
            // 
            // rbCroatian
            // 
            resources.ApplyResources(rbCroatian, "rbCroatian");
            rbCroatian.Name = "rbCroatian";
            rbCroatian.Tag = "HR";
            rbCroatian.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            resources.ApplyResources(btnSubmit, "btnSubmit");
            btnSubmit.BackColor = Color.LimeGreen;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Name = "btnSubmit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // gbSource
            // 
            gbSource.Controls.Add(rbApi);
            gbSource.Controls.Add(rbJson);
            resources.ApplyResources(gbSource, "gbSource");
            gbSource.Name = "gbSource";
            gbSource.TabStop = false;
            // 
            // rbApi
            // 
            rbApi.Checked = true;
            resources.ApplyResources(rbApi, "rbApi");
            rbApi.Name = "rbApi";
            rbApi.TabStop = true;
            rbApi.Tag = "API";
            rbApi.UseVisualStyleBackColor = true;
            // 
            // rbJson
            // 
            resources.ApplyResources(rbJson, "rbJson");
            rbJson.Name = "rbJson";
            rbJson.Tag = "JSON";
            rbJson.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbSource);
            Controls.Add(btnSubmit);
            Controls.Add(gbLanguage);
            Controls.Add(gbGenderSelection);
            Name = "Settings";
            gbGenderSelection.ResumeLayout(false);
            gbLanguage.ResumeLayout(false);
            gbSource.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbGenderSelection;
        private GroupBox gbLanguage;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private RadioButton rbEnglish;
        private RadioButton rbCroatian;
        private Button btnSubmit;
        private GroupBox gbSource;
        private RadioButton rbApi;
        private RadioButton rbJson;
    }
}