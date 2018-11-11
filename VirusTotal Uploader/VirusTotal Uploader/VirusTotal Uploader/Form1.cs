/*  Copyright (c) 2018 Samuel Tulach
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

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
        public string api; // API key used by VirusTotal
        public string theme; // Application theme

        public Languages lang; // Language class

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SamuelTulach/VirusTotalUploader"); // Open GitHub Page
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.virustotal.com/"); // Open VirusTotal Page
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings s = new Settings(); // Initialize settings
            s.Show(); // Show settings form
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy; // Set mouse to drag icon if drag data is file
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); // Get all files dropped into form
            foreach (string file in files) CheckFile(file, api); // Check all files each
        }

        /// <summary>
        /// Checks file on VirusTotal
        /// </summary>
        /// <param name="file">String containing file location</param>
        /// <param name="apikey">API key to use for request</param>
        public async void CheckFile(string file, string apikey)
        {
            this.Invoke(new Action(() => label1.Text = lang.GetString("Checking..."))); // Set label text in main thread

            var client = new RestClient("https://www.virustotal.com"); // Initialize RestClient
            var request = new RestRequest("vtapi/v2/file/report", Method.POST); // Initialize RestRequest
            request.AddParameter("apikey", apikey); // Add apikey parameter with API key
            request.AddParameter("resource", GetMD5(file)); // Add resource paramater with file MD5 checksum

            // Execute request
            var asyncHandle = client.ExecuteAsync(request, response => {
                var content = response.Content; // Get content of response
                dynamic json = JsonConvert.DeserializeObject(content); // Deserialize JSON response

                try
                {
                    // Shitty solution to check, but why not?
                    // If it fails code will not continue
                    // TODO: Actually elegant solution
                    Console.WriteLine(json.permalink.ToString()); // Try to echo file permaling, if it does not exist, throw exception and upload file

                    DialogResult dialogResult = MessageBox.Show(lang.GetString("This file was already scanned on ") + json.scan_date + "\n\n" + lang.GetString("Do you want to view results of scan or rescan file? (\"Yes\" to view, \"No\" to rescan)"), lang.GetString("File is already in database"), MessageBoxButtons.YesNo,MessageBoxIcon.Information); // Show dialog with information about previous scan
                    if (dialogResult == DialogResult.Yes) // Check dialog result
                    {
                        Process.Start(json.permalink.ToString()); // Open browser with file link
                        ResetLabel(); // Set label text back
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        UploadFile(file, apikey); // Upload file for re-scan
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
                        MessageBox.Show(err.ToString() + "\n\n" + error.ToString(), lang.GetString("Fatal Error"), MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error messagebox
                        ResetLabel(); // Set label text back
                    }
                }
            });
        }

        public async void UploadFile(string file, string apikey)
        {
            this.Invoke(new Action(() => label1.Text = lang.GetString("Uploading..."))); // Set label text in main thread

            var client = new RestClient("https://www.virustotal.com"); // Initialize RestClient (again)
            var request = new RestRequest("vtapi/v2/file/scan", Method.POST); // Initialize RestRequest (again and again)
            request.AddParameter("apikey", apikey); // Add apikey parameter with API key
            request.AddFile("file", file); // Add file in file parameter

            if (new FileInfo(file).Length > 32000000)
            {
                DialogResult dialogResult = MessageBox.Show("Your file has more than 32MB. Public VirusTotal API does not support file larger than 32MB. Do you want to continue? (Click ok to continue, cancel to stop upload)", "File is too large", MessageBoxButtons.OKCancel, MessageBoxIcon.Information); // Show information dialog
                if (dialogResult == DialogResult.Cancel) // Check dialog result
                {
                    ResetLabel();
                    return;
                }
            }

            //IRestResponse response = client.Execute(request);

            // Execute request
            var asyncHandle = client.ExecuteAsync(request, response => {
                var content = response.Content; // Get content from response
                if (content.Contains("<html>")) // Check if response is in HTML (there was some issues with large files)
                {
                    MessageBox.Show("Response from VirusTotal is in HTML. This is probably because your file is too large.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Display error dialog
                    ResetLabel();
                    return;
                }
                dynamic json = JsonConvert.DeserializeObject(content); // Deserialize JSON

                try
                {
                    Process.Start(json.permalink.ToString()); //  Open link in browser
                }
                catch (Exception error)
                {
                    try
                    {
                        MessageBox.Show(lang.GetString("VirusTotal response: ") + json.verbose_msg.ToString() + "\n\n" + lang.GetString("Program error: ") + error.ToString(), lang.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error dialog
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString(), lang.GetString("Fatal Error"), MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error dialog of showing error dialog
                    }
                }
                ResetLabel(); // Reset label text
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lang = new Languages(); // Initialize language class
            lang.Init(); // Run init function

            label1.Text = lang.GetString("Drag file here"); // Set label text
            linkLabel3.Text = lang.GetString("Settings"); // Set settings link text

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini")) // Check if settings file exists
            {
                MessageBox.Show(lang.GetString("No settings file found!\n\nThis is because you probably opened this app for first time. Please go to settings and add API key."), lang.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error dialog
            } else
            {
                var parser = new FileIniDataParser(); // Initialize ini file parser
                IniData data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini"); // Load settings file
                api = data["General"]["ApiKey"];  // Get apikey
                theme = data["General"]["Theme"]; // Get theme
            }

            if (theme == "dark") // Check theme
            {
                this.BackColor = ColorTranslator.FromHtml("#0a0a0a"); // Set back color
                this.ForeColor = Color.WhiteSmoke; // Set fore color
                panel2.BackColor = ColorTranslator.FromHtml("#383838"); // Set panel back color to beautiful grey
                // Set link color
                linkLabel1.LinkColor = ColorTranslator.FromHtml("#b2b2b2");
                linkLabel2.LinkColor = ColorTranslator.FromHtml("#b2b2b2");
                linkLabel3.LinkColor = ColorTranslator.FromHtml("#b2b2b2");
            }

            string[] args = Environment.GetCommandLineArgs(); // Get program arguments
            if (args.Length > 1) {
                CheckFile(args[1], api); // Upload file
            }
        }

        /// <summary>
        /// Get MD5 checksum
        /// </summary>
        /// <param name="filename">File location</param>
        /// <returns></returns>
        public String GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    byte[] hashBytes = md5.ComputeHash(stream); // Get bytes
                    StringBuilder sb = new StringBuilder(); // Initialize StringBuilder
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2")); // Append formated bytes to string
                    }
                    return sb.ToString(); // Return hash
                }
            }
        }

        // Make window movable
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

        // Make window shadow
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // Exit app
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimize window
        }

        /// <summary>
        /// Resets text if information label
        /// </summary>
        public void ResetLabel()
        {
            this.Invoke(new Action(() => label1.Text = lang.GetString("Drag file here"))); // Reset label text
        }
    }
}
