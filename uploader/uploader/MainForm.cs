using System;
using System.IO;
using System.Windows.Forms;
using DarkUI.Forms;

namespace uploader
{
    public partial class MainForm : DarkForm
    {
        private SettingsForm _settingsForm = new SettingsForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set working directory to exe location because of language files
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            //LocalizationHelper.Export();
            
            LocalizationHelper.Update();

            dragLabel.Text = LocalizationHelper.Base.MainForm_DragFileOrFolder;
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

            var filesOrFolders = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var fileOrFolder in filesOrFolders)
            {
                ProcessPath(settings, fileOrFolder, true);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var settings = Settings.LoadSettings();
            var args = Environment.GetCommandLineArgs();

            if (args.Length == 2)
            {
                var fileOrFolder = args[1]; // Second argument because .NET puts program filename to the first
                ProcessPath(settings, fileOrFolder, false);
            }
        }

        private void ProcessPath(Settings settings, string fileOrFolder, bool reopen)
        {
            var uploadForm = new UploadForm(this, settings, reopen, fileOrFolder);
            uploadForm.Show();
            Hide();
        }
    }
}
