using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace uploader
{
    public partial class SettingsForm : DarkForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private string GetSettingsFilename()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\vtu_settings.json";
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var settings = Settings.LoadSettings();

            apiTextbox.Text = settings.ApiKey;
            languageCombo.Text = settings.Language;

            var languages = LocalizationHelper.GetLanguages();
            languageCombo.Items.Clear();
            foreach (var language in languages)
            {
                languageCombo.Items.Add(language);
            }

            generalGroupBox.Text = LocalizationHelper.Base.SettingsForm_General;
            apiLabel.Text = LocalizationHelper.Base.SettingsForm_Key;
            getApiButton.Text = LocalizationHelper.Base.SettingsForm_Get;
            languageLabel.Text = LocalizationHelper.Base.SettingsForm_Language;
            saveButton.Text = LocalizationHelper.Base.SettingsForm_Save;
            openButton.Text = LocalizationHelper.Base.SettingsForm_Open;
            this.Text = LocalizationHelper.Base.SettingsForm_Title;

            //LocalizationHelper.Export();
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            var file = Settings.GetSettingsFilename();
            if (!File.Exists(file))
            {
                statusLabel.Text = LocalizationHelper.Base.Message_NoSettings;
                return;
            }
            
            var args = $"/e, /select, \"{Settings.GetSettingsFilename()}\"";

            var info = new ProcessStartInfo {FileName = "explorer", Arguments = args};
            Process.Start(info);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var settings = new Settings
            {
                ApiKey = apiTextbox.Text, 
                Language = languageCombo.Text
            };

            Settings.SaveSettings(settings);
            statusLabel.Text = LocalizationHelper.Base.Message_Saved;
        }

        private void getApiButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://developers.virustotal.com/reference");
        }
    }
}
