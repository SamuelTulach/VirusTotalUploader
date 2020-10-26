using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DarkUI.Forms;

namespace uploader
{
    public partial class SettingsForm : DarkForm
    {
        private string sendToPath;
        public SettingsForm()
        {
            InitializeComponent();
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            sendToPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\SendTo\\VirusTotal.com.lnk");

            sendToButton.Text = File.Exists(sendToPath) ? LocalizationHelper.Base.SettingsForm_RemoveFromSendToMenu : LocalizationHelper.Base.SettingsForm_AddToSendToMenu;

            var settings = Settings.LoadSettings();

            apiTextbox.Text = settings.ApiKey;
            directCheckbox.Checked = settings.DirectUpload;

            var languages = LocalizationHelper.GetLanguages();
            languageCombo.Items.Clear();
            foreach (var language in languages)
            {
                languageCombo.Items.Add(language);
            }

            if (string.IsNullOrEmpty(settings.Language))
            {
                var defaultLanguage = languageCombo.Items.Add("Default (Build-in English)");
                languageCombo.SelectedIndex = defaultLanguage;
            }
            else
            {
                var index = languageCombo.Items.IndexOf(settings.Language);
                languageCombo.SelectedIndex = index;
            }

            generalGroupBox.Text = LocalizationHelper.Base.SettingsForm_General;
            apiLabel.Text = LocalizationHelper.Base.SettingsForm_Key;
            getApiButton.Text = LocalizationHelper.Base.SettingsForm_Get;
            languageLabel.Text = LocalizationHelper.Base.SettingsForm_Language;
            saveButton.Text = LocalizationHelper.Base.SettingsForm_Save;
            openButton.Text = LocalizationHelper.Base.SettingsForm_Open;
            this.Text = LocalizationHelper.Base.SettingsForm_Title;
            directCheckbox.Text = LocalizationHelper.Base.SettingsForm_DirectUpload;

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
                Language = languageCombo.Text,
                DirectUpload = directCheckbox.Checked
            };

            Settings.SaveSettings(settings);
            //statusLabel.Text = LocalizationHelper.Base.Message_Saved;
            MessageBox.Show(LocalizationHelper.Base.Message_Saved, "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information); // TODO: custom messagebox with dark theme (because default win32 one is annoying)

            // Needs full restart to initialize main form strings again
            Application.Restart();
            Environment.Exit(0);
        }

        private void getApiButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://developers.virustotal.com/reference");
        }

        private void SendToButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(sendToPath))
                File.Delete(sendToPath);
            else
            {
                var shell = new IWshRuntimeLibrary.WshShell();

                var windowsApplicationShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(sendToPath);
                windowsApplicationShortcut.Description      = "Upload file to VirusTotal.com for analysis";
                windowsApplicationShortcut.WorkingDirectory = Application.StartupPath;
                windowsApplicationShortcut.TargetPath       = Application.ExecutablePath;
                windowsApplicationShortcut.Save();
            }

            sendToButton.Text = File.Exists(sendToPath) ? LocalizationHelper.Base.SettingsForm_RemoveFromSendToMenu : LocalizationHelper.Base.SettingsForm_AddToSendToMenu;

        }
    }
}
