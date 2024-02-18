using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace uploader
{
    public partial class MainForm : DarkForm
    {
        private SettingsForm _settingsForm = new SettingsForm();
		int maxArgs = 10;

		public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set working directory to exe location because of language files
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //LocalizationHelper.Export();
            
            LocalizationHelper.Update();

            dragLabel.Text = LocalizationHelper.Base.MainForm_DragFile;
            moreLabel.Text = LocalizationHelper.Base.MainForm_More;
        }

        private void moreLabel_Click(object sender, EventArgs e)
        {
            if (_settingsForm.IsDisposed)
            {
                _settingsForm = new SettingsForm();
            }
            _settingsForm.Show();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var settings = Settings.LoadSettings();

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
			showMultipleUploadForms(files, settings);
		}

		private void showMultipleUploadForms(string[] files, Settings settings)
		{
			foreach (var file in files)
			{
				var uploadForm = new UploadForm(this, settings, true, file);
				uploadForm.Show();
				this.Hide();
			}
		}

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var settings = Settings.LoadSettings();
            var args = Environment.GetCommandLineArgs();

			if (args.Length >= 2 && args.Length <= maxArgs)
			{
				var files = args.ToList()
								.GetRange(1, args.Count()-1).ToArray();
				showMultipleUploadForms(files, settings);
			}
			else if (args.Length > maxArgs)
			{
				string message = "Number of files exceeds maximum";
				string title = $"The app can handle max {maxArgs} files at once.";
				MessageBoxButtons buttons = MessageBoxButtons.OK;
				DialogResult result = MessageBox.Show(message, title, buttons);
				if (result == DialogResult.Yes)
				{
					this.Close();
				}
			}
		}
    }
}
