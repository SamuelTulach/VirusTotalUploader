using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using RestSharp;

namespace uploader
{
    public partial class UploadForm : DarkForm
    {
        private readonly bool _reopen;
        private readonly string _path;
        private readonly MainForm _mainForm;
        private readonly Settings _settings;
        private Thread _uploadThread;
        private RestClient _client;
        private bool _isFolder;
        private List<string> _filesToUpload;

        public UploadForm(MainForm mainForm, Settings settings, bool reopen, string path)
        {
            _path = path;
            _mainForm = mainForm;
            _settings = settings;
            _reopen = reopen;
            _isFolder = Directory.Exists(_path);

            InitializeComponent();
        }

        private void ChangeStatus(string text)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => ChangeStatus(text)));
                return;
            }

            statusLabel.Text = text;
        }

        private void Finish(bool resetText)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => Finish(resetText)));
                return;
            }

            if (resetText)
            {
                ChangeStatus(LocalizationHelper.Base.Message_Idle);
            }

            uploadButton.Text = LocalizationHelper.Base.UploadForm_Upload;
        }

        private void CloseWindow()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => CloseWindow()));
                return;
            }

            this.Close();
        }

        private void DisplayError(string error)
        {
            var messageBox = new DarkMessageBox(error, LocalizationHelper.Base.UploadForm_Error, DarkMessageBoxIcon.Error, DarkDialogButton.Ok);
            messageBox.ShowDialog();
        }

        private void Upload()
        {
            if (string.IsNullOrEmpty(_settings.ApiKey))
            {
                MessageBox.Show(LocalizationHelper.Base.UploadForm_NoApiKey, LocalizationHelper.Base.UploadForm_InvalidKey, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_settings.ApiKey.Length != 64)
            {
                MessageBox.Show(LocalizationHelper.Base.UploadForm_InvalidLength, LocalizationHelper.Base.UploadForm_InvalidKey, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ChangeStatus(LocalizationHelper.Base.Message_Init);
            _client = new RestClient("https://www.virustotal.com");

            if (_isFolder)
            {
                _filesToUpload = Directory.GetFiles(_path, "*.*", SearchOption.AllDirectories).ToList();
            }
            else
            {
                _filesToUpload = new List<string> { _path };
            }

            foreach (var file in _filesToUpload)
            {
                UploadFile(file);
            }

            Finish(true);
        }

        private void UploadFile(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                DisplayError($"File {fullPath} does not exist.");
                return;
            }

            var fileName = Path.GetFileName(fullPath);
            ChangeStatus($"Checking {fileName}...");
            var reportRequest = new RestRequest("vtapi/v2/file/report", Method.Post);
            reportRequest.AddParameter("apikey", _settings.ApiKey);
            reportRequest.AddParameter("resource", Utils.GetMD5(fullPath));

            var reportResponse = _client.Execute(reportRequest);
            var reportContent = reportResponse.Content;
            dynamic reportJson = JsonConvert.DeserializeObject(reportContent);

            try
            {
                var reportLink = reportJson.permalink.ToString();
                Process.Start(reportLink);
            }
            catch (RuntimeBinderException)
            {
                // Json does not contain permalink which means it's a new file (or the request failed)
                ChangeStatus($"Uploading {fileName}...");
                var scanRequest = new RestRequest("vtapi/v2/file/scan", Method.Post);
                scanRequest.AddParameter("apikey", _settings.ApiKey);
                scanRequest.AddFile("file", fullPath);

                var scanResponse = _client.Execute(scanRequest);
                var scanContent = scanResponse.Content;
                dynamic scanJson = JsonConvert.DeserializeObject(scanContent);

                try
                {
                    string sha256 = scanJson.sha256.ToString();
                    string scanId = scanJson.scan_id.ToString();

                    var scanLink = $"https://www.virustotal.com/gui/file/{sha256}/detection/{scanId}";

                    Process.Start(scanLink);
                }
                catch (Exception ex)
                {
                    DisplayError($"Failed to get link for {fileName}. Error: {ex.Message}");
                }
            }
        }

        private void StartUploadThread()
        {
            if (_uploadThread != null && _uploadThread.IsAlive)
            {
                _uploadThread.Abort();
                uploadButton.Text = LocalizationHelper.Base.UploadForm_Upload;
                return;
            }
            uploadButton.Text = LocalizationHelper.Base.UploadForm_Cancel;

            _uploadThread = new Thread(Upload);
            _uploadThread.Start();
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
            if (_isFolder)
            {
                mdTextbox.Text = "N/A (Folder)";
                shaTextbox.Text = "N/A (Folder)";
                sha2Textbox.Text = "N/A (Folder)";
            }
            else
            {
                mdTextbox.Text = Utils.GetMD5(_path);
                shaTextbox.Text = Utils.GetSHA1(_path);
                sha2Textbox.Text = Utils.GetSHA256(_path);
            }

            settingsGroup.Text = LocalizationHelper.Base.UploadForm_Info;
            uploadButton.Text = LocalizationHelper.Base.UploadForm_Upload;
            statusLabel.Text = LocalizationHelper.Base.Message_Idle;

            if (_settings.DirectUpload)
            {
                StartUploadThread();
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            StartUploadThread();
        }

        private void UploadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_reopen)
            {
                _mainForm.Show();
            }
            else
            {
                _mainForm.Close();
            }
        }
    }
}