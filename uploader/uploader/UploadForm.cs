using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace uploader
{
    public partial class UploadForm : DarkForm
    {
        private readonly bool _reopen;
        private readonly string _fileOrFolderName;
        private readonly MainForm _mainForm;
        private readonly Settings _settings;
        private Thread _uploadThread;
        private RestClient _client;
        private string _resource;

        public UploadForm(MainForm mainForm, Settings settings, bool reopen, string fileOrFolderName)
        {
            _fileOrFolderName = fileOrFolderName;
            _mainForm = mainForm;
            _settings = settings;
            _reopen = reopen;
            
            InitializeComponent();
        }

        private void ChangeStatus(string text)
        {
            this.InvokeIfRequired(() => { statusLabel.Text = text; });
        }

        private void Finish(bool resetText)
        {
            this.InvokeIfRequired(() => {
                if (resetText)
                {
                    ChangeStatus(LocalizationHelper.Base.Message_Idle);
                }

                uploadButton.Text = LocalizationHelper.Base.UploadForm_Upload;
            });
        }

        private void CloseWindow()
        {
            this.InvokeIfRequired(Close);
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

            string[] paths;
            if (Directory.Exists(_fileOrFolderName))
            {
                try
                {
                    paths = Directory.GetFiles(_fileOrFolderName, "*", SearchOption.AllDirectories);
                }
                catch (UnauthorizedAccessException)
                {
                    ChangeStatus(LocalizationHelper.Base.UploadForm_NoAccessToDirectory);
                    Finish(false);
                    return;
                }
            }
            else if (File.Exists(_fileOrFolderName))
            {
                paths = new [] { _fileOrFolderName };
            }
            else
            {
                throw new FileNotFoundException();
            }

            ChangeStatus(LocalizationHelper.Base.Message_Check);
            var result = true;
            foreach (var path in paths)
            {
                var reportRequest = new RestRequest("vtapi/v2/file/report", Method.POST);
                reportRequest.AddParameter("apikey", _settings.ApiKey);
                reportRequest.AddParameter("resource", _resource);

                var reportResponse = _client.Execute(reportRequest);

                // Here you can see quote or api key limits: var message = reportResponse.Headers.FirstOrDefault(x => x.Name == "X-Api-Message");
                if (!string.IsNullOrEmpty(reportResponse.Content))
                {
                    try
                    {
                        var reportJson = (JObject)JsonConvert.DeserializeObject(reportResponse.Content);
                        Process.Start(reportJson.SelectToken("permalink").Value<string>());
                        continue;
                    }
                    catch
                    {
                        // not yet received, but weird exceptions out there
                    }
                }

                // Json does not contain permalink which means it's a new file (or the request failed)
                ChangeStatus(LocalizationHelper.Base.Message_Upload);
                var scanRequest = new RestRequest("vtapi/v2/file/scan", Method.POST);
                scanRequest.AddParameter("apikey", _settings.ApiKey);
                scanRequest.AddFile("file", path);

                var scanResponse = _client.Execute(scanRequest);
                if (scanResponse.ErrorException is OutOfMemoryException || scanResponse.ErrorException is IOException && scanResponse.ErrorException?.InnerException is SocketException sEx && sEx.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    ChangeStatus(LocalizationHelper.Base.Message_FileTooBig);
                    result = false;
                    continue;
                }
                try
                {
                    var scanJson = (JObject)JsonConvert.DeserializeObject(scanResponse.Content);
                    var scanLink = scanJson.SelectToken("permalink").Value<string>();

                    // An example link can look like this:
                    // https://www.virustotal.com/gui/file/<filehash_or_resource_id>/detection/<scanid>
                    // If we don't remove the the scanid, then it will fail on new files since the scan did not finish
                    // Removing it like this will show the analysis progress for new files
                    scanLink = scanLink.Remove(scanLink.IndexOf("/detection"));

                    Process.Start(scanLink);
                }
                catch (Exception)
                {
                    // Response does not contain permalink so it failed
                    ChangeStatus(LocalizationHelper.Base.Message_NoLink);
                    result = false;
                }
            }

            if (_settings.DirectUpload) CloseWindow();

            Finish(result);
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

            _resource = mdTextbox.Text;
            _uploadThread = new Thread(Upload);
            _uploadThread.Start();
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(_fileOrFolderName))
            {
                mdTextbox.Text = _fileOrFolderName;
                shaTextbox.Visible = false;
                sha2Textbox.Visible = false;

                darkLabel1.Text = LocalizationHelper.Base.UploadForm_Folder;
                darkLabel2.Visible = false;
                darkLabel3.Visible = false;

                settingsGroup.Text = LocalizationHelper.Base.UploadForm_FolderInfo;
            }
            else
            {
                settingsGroup.Text = LocalizationHelper.Base.UploadForm_FileInfo;

                try
                {
                    mdTextbox.Text = Utils.GetMD5(_fileOrFolderName);
                    shaTextbox.Text = Utils.GetSHA1(_fileOrFolderName);
                    sha2Textbox.Text = Utils.GetSHA256(_fileOrFolderName);
                }
                catch (UnauthorizedAccessException)
                {
                    mdTextbox.Text = LocalizationHelper.Base.UploadForm_NoAccessToFile;
                    shaTextbox.Text = LocalizationHelper.Base.UploadForm_NoAccessToFile;
                    sha2Textbox.Text = LocalizationHelper.Base.UploadForm_NoAccessToFile;
                }
            }

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