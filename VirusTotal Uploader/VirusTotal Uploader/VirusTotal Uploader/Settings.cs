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

using Microsoft.Win32;
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
using IniParser;
using IniParser.Model;

namespace VirusTotal_Uploader
{
    public partial class Settings : Form
    {

        public Languages lang;

        public Settings()
        {
            InitializeComponent();
        }

        private string GetMD5()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            FileStream stream = new FileStream(Process.GetCurrentProcess().MainModule.FileName, FileMode.Open, FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VirusTotal Uploader\n\n" + GetMD5() + "\n\n" + @"
Copyright (c) 2018 Samuel Tulach
    
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see < https://www.gnu.org/licenses/>.","About VirusTotal Uploader", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string darkmode = "light";
            if (checkBox1.Checked)
            {
                darkmode = "dark";
            }
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "settings.txt", textBox1.Text + ":" + darkmode + ":" + comboBox1.Text);
            MessageBox.Show(lang.GetString("Settings saved!"), lang.GetString("Yeah!"), MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            SaveSettings();
            MessageBox.Show(lang.GetString("Settings saved!"), lang.GetString("Yeah!"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini");
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            lang = new Languages();
            lang.Init();

            label2.Text = lang.GetString("API key");
            label3.Text = lang.GetString("To get API key log-in on VirusTotal and under account select \"My API key\"");
            button4.Text = lang.GetString("Add to content menu");
            button5.Text = lang.GetString("Remove from content menu");
            groupBox1.Text = lang.GetString("General");
            groupBox2.Text = lang.GetString("Other");
            button3.Text = lang.GetString("About");
            checkBox1.Text = lang.GetString("Use dark theme");
            label5.Text = lang.GetString("Language");
            button1.Text = lang.GetString("Save settings");
            button2.Text = lang.GetString("Open settings file");
            label4.Text = lang.GetString("Restart app to apply settings");

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini"))
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini");
                textBox1.Text = data["General"]["ApiKey"];
                string theme = data["General"]["Theme"];
                if (theme == "dark")
                {
                    checkBox1.Checked = true;
                }
            }
        }

        private const string MenuName = "*\\shell\\UploaderMenuOption";
        private const string Command = "*\\shell\\UploaderMenuOption\\command";
        public void RegisterContentMenu()
        {
            RegistryKey regmenu = null;
            RegistryKey regcmd = null;
            try
            {
                regmenu = Registry.ClassesRoot.CreateSubKey(MenuName);
                if (regmenu != null)
                    regmenu.SetValue("", lang.GetString("Scan with VirusTotal"));
                regcmd = Registry.ClassesRoot.CreateSubKey(Command);
                if (regcmd != null)
                    regcmd.SetValue("", System.Reflection.Assembly.GetEntryAssembly().Location + " %1");
                MessageBox.Show(lang.GetString("Added to content menu"), lang.GetString("Yeah!"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), lang.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (regmenu != null)
                    regmenu.Close();
                if (regcmd != null)
                    regcmd.Close();
            }
        }

        public void UnRegisterContentMenu()
        {
            try
            {
                RegistryKey reg = Registry.ClassesRoot.OpenSubKey(Command);
                if (reg != null)
                {
                    reg.Close();
                    Registry.ClassesRoot.DeleteSubKey(Command);
                }
                reg = Registry.ClassesRoot.OpenSubKey(MenuName);
                if (reg != null)
                {
                    reg.Close();
                    Registry.ClassesRoot.DeleteSubKey(MenuName);
                }
                MessageBox.Show(lang.GetString("Removed from content menu"), lang.GetString("Yeah!"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), lang.GetString("Error"), MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegisterContentMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UnRegisterContentMenu();
        }

        public void SaveSettings()
        {
            string darkmode = "light";
            if (checkBox1.Checked)
            {
                darkmode = "dark";
            }

            var parser = new FileIniDataParser();
            IniData data = new IniData();
            data["General"]["ApiKey"] = textBox1.Text;
            data["General"]["Theme"] = darkmode;
            data["General"]["Language"] = comboBox1.Text;
            parser.WriteFile(AppDomain.CurrentDomain.BaseDirectory + "Settings.ini", data);
        }
    }
}
