using Dao.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupBox = System.Windows.Forms.GroupBox;
using static System.Windows.Forms.Application;
using System.Windows.Forms;


namespace WinFormsApp.Forms
{
    public partial class Settings : Form
    {

        private readonly IRepository _repository;
        public Settings()
        {
            InitializeComponent();
            _repository = RepositoryFactory.GetRepository();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ConfirmSettingsChange()) return;

            try
            {
                string selectedTournamentType = GetCheckedTagFromGroupBox(gbGenderSelection);
                string selectedLanguage = GetCheckedTagFromGroupBox(gbLanguage);
                string selectedSource = GetCheckedTagFromGroupBox(gbSource);

                _repository.SaveTournamentSettings(selectedTournamentType, selectedLanguage, selectedSource);
                _repository.SetChosenTeamToSettings(string.Empty);
                LanguageHelper.ApplyCulture(selectedLanguage, this, GetType());

                NavigateAfterSave();
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is IOException || ex is CultureNotFoundException)
            {
                ShowError(Resources.Resources.unexpectedError);
            }
        }

       
        private bool ConfirmSettingsChange()
        {
            DialogResult result = MessageBox.Show(
              Resources.Resources.settingsmessBoxBody,
              Resources.Resources.settingsmessBoxTitle,
              MessageBoxButtons.OKCancel,
              MessageBoxIcon.Question
          );

            return result == DialogResult.OK;
        }

        private string GetCheckedTagFromGroupBox(GroupBox groupBox)
        {
            var selectedRadio = groupBox.Controls
                                .OfType<RadioButton>()
                                .FirstOrDefault(r => r.Checked);

            return selectedRadio?.Tag?.ToString() ?? string.Empty;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NavigateAfterSave()
        {
            if (OpenForms.Count > 1)
            {
                Close();
                return;
            }

            Hide();
            using (var mainForm = new WorldCup())
            {
                mainForm.ShowDialog();
            }
            Close();
        }
    }
}
