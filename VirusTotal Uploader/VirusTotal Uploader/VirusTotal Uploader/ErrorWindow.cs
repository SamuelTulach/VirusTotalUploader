using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusTotal_Uploader
{
    public partial class ErrorWindow : Form
    {
        public string FormTitle = "Fatal Error";
        public string Error = "No error has been reported. Please try debugging program!";


        private ArrayList GetInformation(string qry)
        {
            ManagementObjectSearcher searcher;
            int i = 0;
            ArrayList arrayListInformationCollactor = new ArrayList();
            try
            {
                searcher = new ManagementObjectSearcher("SELECT * FROM " + qry);
                foreach (ManagementObject mo in searcher.Get())
                {
                    i++;
                    PropertyDataCollection searcherProperties = mo.Properties;
                    foreach (PropertyData sp in searcherProperties)
                    {
                        arrayListInformationCollactor.Add(sp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return arrayListInformationCollactor;
        }

        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void ErrorWindow_Load(object sender, EventArgs e)
        {
            this.Name = FormTitle;

            string Info = "";
            ArrayList OSInfo = GetInformation("Win32_OperatingSystem");
            foreach (PropertyData sp in OSInfo)
            {
                Info += sp.Name + " : " + sp.Value + "\n";
            }
            Info += "\n";
            ArrayList SystemInfo = GetInformation("Win32_ComputerSystem");
            foreach (PropertyData sp in OSInfo)
            {
                Info += sp.Name + " : " + sp.Value + "\n";
            }
            Info += "\n\n";
            richTextBox1.Text = Info + Error;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/SamuelTulach/VirusTotalUploader/issues/new");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
