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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusTotal_Uploader
{
    public partial class Form1 : Form
    {
        public string api;
        public string theme;

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
            foreach (string file in files) UploadFile(file, api);
        }

        public async void UploadFile(string file, string apikey)
        {
            label1.Text = "Uploading...";

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
                        MessageBox.Show("VirusTotal response: " + json.verbose_msg.ToString() + "\n\n Program error: " + error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Invoke(new Action(() => label1.Text = "Drag file here"));
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "settings.txt"))
            {
                MessageBox.Show("No settings file found!\n\nThis is because you probably opened this app for first time. Please go to settings and add API key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                string data = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "settings.txt");
                string[] arrayd = data.Split(':');
                api = arrayd[0];
                theme = arrayd[1];
            }

            if (theme == "dark")
            {
                this.BackColor = ColorTranslator.FromHtml("#0a0a0a");
                this.ForeColor = Color.WhiteSmoke;
            }

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) {
                UploadFile(args[1], api);
            }
        }
    }
}
