using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusTotal_Uploader
{
    public class Languages
    {
        TranslationClient client;

        public void Init()
        {
            // This class is made for future languages support
        }

        public string GetString(string text)
        {
            return text;
        }
    }
}
