using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace uploader
{
    public class Settings
    {
        public string ApiKey = "";
        public string Language = "";
        public bool DirectUpload = false;


     

        public static Settings LoadSettings()
        {
			return new Settings()
			{
				ApiKey = Properties.Settings.Default.ApiKey,
				Language = Properties.Settings.Default.Language,
				DirectUpload = Properties.Settings.Default.DirectUpload
			};
        }
    }
}
