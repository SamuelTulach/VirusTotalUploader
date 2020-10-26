using System.IO;
using Newtonsoft.Json;

namespace uploader
{
    internal class LocalizationHelper
    {
        private const string LocalFolder = "local";
        public static LocalizationBase Base;
        
        public static string[] GetLanguages()
        {
            return Directory.Exists(LocalFolder) ? Directory.GetFiles(LocalFolder) : new []{ "" };
        }

        public static void Load(string path)
        {
            var context = File.ReadAllText(path);
            Base = JsonConvert.DeserializeObject<LocalizationBase>(context);
        }

        public static void Update()
        {
            var settings = Settings.LoadSettings();
            if (!string.IsNullOrEmpty(settings.Language))
            {
                Load(settings.Language);
            }
            else
            {
                Base = new LocalizationBase();
            }
        }

        // Used to create Json for new version
        public static void Export()
        {
            Base = new LocalizationBase();
            var serialized = JsonConvert.SerializeObject(LocalizationHelper.Base, Formatting.Indented);
            File.WriteAllText("export.json", serialized);
        }
    }
}
