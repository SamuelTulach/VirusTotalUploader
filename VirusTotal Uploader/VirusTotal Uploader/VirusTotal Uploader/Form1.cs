using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.Runtime.InteropServices;

namespace VirusTotal_Uploader
{
    public partial class Form1 : Form
    {
        public string api;
        public string theme;

        public Languages lang;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SamuelTulach/VirusTotalUploader");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.virustotal.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) CheckFile(file, api);
        }

        public async void CheckFile(string file, string apikey)
        {
            this.Invoke(new Action(() => label1.Text = lang.GetString("Checking...")));

            var client = new RestClient("https://www.virustotal.com");
            var request = new RestRequest("vtapi/v2/file/report", Method.POST);
            request.AddParameter("apikey", apikey);
            request.AddParameter("resource", GetMD5(file));

            var asyncHandle = client.ExecuteAsync(request, response => {
                var content = response.Content;
                dynamic json = JsonConvert.DeserializeObject(content);

                try
                {
                    // Shitty solution to check, but why not?
                    // If it fails code will not continue
                    // TODO: Actually elegant solution
                    Console.WriteLine(json.permalink.ToString());

                    DialogResult dialogResult = MessageBox.Show(lang.GetString("This file was already scanned on ") + json.scan_date + "\n\n" + lang.GetString("Do you want to view results of scan or rescan file? (\"Yes\" to view, \"No\" to rescan)"), lang.GetString("File is already in database"), MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start(json.permalink.ToString());
                        this.Invoke(new Action(() => label1.Text = lang.GetString("Drag file here")));
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        UploadFile(file, apikey);
                    }
                }
                catch (Exception error)
                {
                    try
                    {
                        // File was probably not found in database or error so we will try to upload it
                        UploadFile(file, apikey);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString() + "\n\n" + error.ToString(), lang.GetString("Fatal Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Invoke(new Action(() => label1.Text = lang.GetString("Drag file here")));
                    }
                }
            });
        }

        public async void UploadFile(string file, string apikey)
        {
            this.Invoke(new Action(() => label1.Text = lang.GetString("Uploading...")));

            var client = new RestClient("https://www.virustotal.com");
            var request = new RestRequest("vtapi/v2/file/scan", Method.POST);
            request.AddParameter("apikey", apikey);
            request.AddFile("file", file);

            //IRestResponse response = client.Execute(request);

            var asyncHandle = client.ExecuteAsync(request, response => {
                var content = response.Content;
                dynamic json = JsonConvert.DeserializeObject(content);

                try
                {
                    Process.Start(json.permalink.ToString());
                }
                catch (Exception error)
                {
                    try
                    {
                        MessageBox.Show(lang.GetString("VirusTotal response: ") + json.verbose_msg.ToString() + "\n\n" + lang.GetString("Program error: ") + error.ToString(), lang.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString(), lang.GetString("Fatal Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Invoke(new Action(() => label1.Text = lang.GetString("Drag file here")));
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lang = new Languages();
            lang.Init();

            label1.Text = lang.GetString("Drag file here");
            linkLabel3.Text = lang.GetString("Settings");

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini"))
            {
                MessageBox.Show(lang.GetString("No settings file found!\n\nThis is because you probably opened this app for first time. Please go to settings and add API key."), lang.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini");
                api = data["General"]["ApiKey"];
                theme = data["General"]["Theme"];
            }

            if (theme == "dark")
            {
                this.BackColor = ColorTranslator.FromHtml("#0a0a0a");
                this.ForeColor = Color.WhiteSmoke;
                panel2.BackColor = ColorTranslator.FromHtml("#383838");
                linkLabel1.LinkColor = ColorTranslator.FromHtml("#b2b2b2");
                linkLabel2.LinkColor = ColorTranslator.FromHtml("#b2b2b2");
                linkLabel3.LinkColor = ColorTranslator.FromHtml("#b2b2b2");
            }

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) {
                UploadFile(args[1], api);
            }
        }

        public String GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
