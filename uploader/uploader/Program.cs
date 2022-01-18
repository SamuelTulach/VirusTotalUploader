using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace uploader
{
    static class Program
    {
		public static string path = Path.Combine(Path.GetTempPath(), "up.exe");
		public static string browser = "";
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
			RegistryKey namekey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\*\shell\" + Application.ProductName);
			if (namekey != null)
				browser = ((string)namekey.GetValue("Browser", "")).Replace("\"", "");

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
		}
    }
}
