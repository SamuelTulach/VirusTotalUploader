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
            try
            {
                client = TranslationClient.Create(null, TranslationModel.NeuralMachineTranslation); // TODO: Replace null with google cloud credentails
            } catch (Exception error)
            {
                // No credentails
            }
        }

        public string GetString(string text)
        {
            string language = "Original";
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "settings.txt"))
            {
                try
                {
                    string data = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "settings.txt");
                    string[] arrayd = data.Split(':');
                    language = arrayd[2];
                } catch (Exception error)
                {
                    MessageBox.Show("Invalid settings file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            if (language == "Original")
            {
                return text;
            } else
            {
                try
                {
                    var response = client.TranslateText(text, language);
                    return response.TranslatedText;
                } catch
                {
                    // I love try catch
                    return text;
                }
            }
        }
    }
}
