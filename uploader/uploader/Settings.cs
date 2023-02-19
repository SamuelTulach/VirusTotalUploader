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

        public static string GetSettingsFilename()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "vtu_settings.json");
        }

        public static void SaveSettings(Settings settings)
        {
            if (settings.Language.Contains("Default"))
            {
                settings.Language = "";
            }
            
            var serialized = JsonConvert.SerializeObject(settings);
            var file = GetSettingsFilename();

            if (File.Exists(file))
                File.Delete(file);

            File.WriteAllText(file, serialized);

            LocalizationHelper.Update();
        }

        public static Settings LoadSettings()
        {
            var file = GetSettingsFilename();

            if (!File.Exists(file))
                return new Settings();

            var context = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<Settings>(context);
        }
    }
}
