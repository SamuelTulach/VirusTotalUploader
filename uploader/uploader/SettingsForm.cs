using System;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Linq;
using DarkUI.Forms;
using Microsoft.Win32;

namespace uploader
{
    public partial class SettingsForm : DarkForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var settings = Settings.LoadSettings();

            apiTextbox.Text = settings.ApiKey;
            directCheckbox.Checked = settings.DirectUpload;
			contextChk.Checked = Properties.Settings.Default.Context;


			var languages = LocalizationHelper.GetLanguages().Reverse().Reverse();
            languageCombo.Items.Clear();
            foreach (var language in languages)
                languageCombo.Items.Add(language);
            

			if (string.IsNullOrEmpty(settings.Language))
				languageCombo.SelectedIndex = 0;
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
            this.Text = LocalizationHelper.Base.SettingsForm_Title;
            directCheckbox.Text = LocalizationHelper.Base.SettingsForm_DirectUpload;
			contextChk.Text = LocalizationHelper.Base.SettingsForm_Context;
			resetBtn.Text = LocalizationHelper.Base.SettingsForm_ResetBtn;
			//LocalizationHelper.Export();
		}


        private void saveButton_Click(object sender, EventArgs e)
        {
            apiTextbox.Text = apiTextbox.Text.Trim();

			Properties.Settings.Default.ApiKey = apiTextbox.Text;
			Properties.Settings.Default.Language = languageCombo.Text;
			Properties.Settings.Default.DirectUpload = directCheckbox.Checked;
			Properties.Settings.Default.Context = contextChk.Checked;
			Properties.Settings.Default.Save();
			LocalizationHelper.Update();

			if (contextChk.Checked)
				addContextEntry();
			else
				removeContextEntry();

            // Needs full restart to initialize main form strings again
            Application.Restart();
            Environment.Exit(0);
        }

		private void addContextEntry()
		{
			RegistryKey shellkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\*\shell", true);
			if (shellkey != null)
			{
				RegistryKey namekey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\*\shell\" + Application.ProductName, true);
				if (namekey == null)
					namekey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\*\shell\" + Application.ProductName, true);

				namekey.SetValue("Icon", "\"" + Application.ExecutablePath + "\"");

				RegistryKey cmdkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\*\shell\" + Application.ProductName + "\\command", true);
				if (cmdkey == null)
					cmdkey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\*\shell\" + Application.ProductName + "\\command", true);

				if (cmdkey != null)
					cmdkey.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");

				cmdkey.Close();
				namekey.Close();
				shellkey.Close();
			}
		}

		private void removeContextEntry()
		{
			using (RegistryKey namekey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\*\shell\", true))
			{
				if (namekey != null)
					try
					{
						namekey.DeleteSubKeyTree(Application.ProductName);
					}
					catch { }
			}
		}

        private void getApiButton_Click(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(Program.browser))
				Process.Start(Program.browser, "https://developers.virustotal.com/reference");
			else
				Process.Start("https://developers.virustotal.com/reference");
        }

		private void ResetBtn_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(LocalizationHelper.Base.SettingsForm_Reset, LocalizationHelper.Base.SettingsForm_Sure, MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				string config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
				DirectoryInfo di = new FileInfo(config).Directory;
				di = di.Parent.Parent;
				if (di.Name == Application.ProductName.Replace(" ","") && di.Exists)
					di.Delete(true);

				apiTextbox.Text = "";
				directCheckbox.Checked = false;
				languageCombo.SelectedIndex = 0;
				contextChk.Checked = false;
				removeContextEntry();
				Application.Restart();
				Environment.Exit(0);
			}
		}
	}
}
