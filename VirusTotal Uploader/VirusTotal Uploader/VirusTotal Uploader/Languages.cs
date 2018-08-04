using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusTotal_Uploader
{
    public class Languages
    {
        public Dictionary<string, string> english;
        public Dictionary<string, string> czech;
        public Dictionary<string, string> russian;

        public void Init()
        {
            /*
              ___           _ _    _    
             | __|_ _  __ _| (_)__| |_  
             | _|| ' \/ _` | | (_-< ' \ 
             |___|_||_\__, |_|_/__/_||_|
                      |___/             
            */
            english = new Dictionary<string, string>();

            english.Add("Checking...", "Checking...");
            english.Add("Uploading...", "Uploading...");
            english.Add("Drag file here", "Drag file here");
            english.Add("Fatal Error", "Fatal Error");
            english.Add("Error", "Error");
            english.Add("This file was already scanned on ", "This file was already scanned on ");
            english.Add("Do you want to view results of scan or rescan file? (\"Yes\" to view, \"No\" to rescan)", "Do you want to view results of scan or rescan file? (\"Yes\" to view, \"No\" to rescan)");
            english.Add("File is already in database", "File is already in database");
            english.Add("VirusTotal response: ", "VirusTotal response: ");
            english.Add(" Program error: ", " Program error: ");
            english.Add("No settings file found!\n\nThis is because you probably opened this app for first time. Please go to settings and add API key.", "No settings file found!\n\nThis is because you probably opened this app for first time. Please go to settings and add API key.");

            english.Add("Settings saved!", "Settings saved!");
            english.Add("Yeah!", "Yeah!");
            english.Add("Scan with VirusTotal", "Scan with VirusTotal");
            english.Add("Added to content menu", "Added to content menu");
            english.Add("Removed from content menu", "Removed from content menu");

            english.Add("About", "About");
            english.Add("API key", "API key");
            english.Add("To get API key log-in on VirusTotal and under account select \"My API key\"", "To get API key log-in on VirusTotal and under account select \"My API key\"");
            english.Add("General", "General");
            english.Add("Other", "Other");
            english.Add("Use dark theme", "Use dark theme");
            english.Add("Add to content menu", "Add to content menu");
            english.Add("Remove from content menu", "Remove from content menu");
            english.Add("Save settings", "Save settings");
            english.Add("Open settings file", "Open settings file");
            english.Add("Restart app to apply settings", "Restart app to apply settings");
            english.Add("Language", "Language");

            english.Add("Settings", "Settings");

            /*
               ___           _    
              / __|______ __| |_  
             | (__|_ / -_) _| ' \ 
              \___/__\___\__|_||_|       
             
            */
            czech = new Dictionary<string, string>();

            czech.Add("Checking...", "Kontrola...");
            czech.Add("Uploading...", "Nahrávání...");
            czech.Add("Drag file here", "Přetáhněte soubor zde");
            czech.Add("Fatal Error", "Fatalní chyba");
            czech.Add("Error", "Chyba");
            czech.Add("This file was already scanned on ", "Soubor už byl naskenován v ");
            czech.Add("Do you want to view results of scan or rescan file? (\"Yes\" to view, \"No\" to rescan)", "Chcete vidět výsledky scanu nebo rescanovat? (\"Ano\" pro zobrazení, \"Ne\" pro rescan)");
            czech.Add("File is already in database", "Soubor už je v databázi");
            czech.Add("VirusTotal response: ", "Odpověď VirusTotal: ");
            czech.Add(" Program error: ", " Chyba programu: ");
            czech.Add("No settings file found!\n\nThis is because you probably opened this app for first time. Please go to settings and add API key.", "Soubor nastavení nebyl nalezen!\n\nTo většinou zanamená, že jste aplikaci otevřeli poprvé. Jděte prosím do nastavení a přidejte API klíč.");

            czech.Add("Settings saved!", "Nastavení uloženo");
            czech.Add("Yeah!", "Yop!");
            czech.Add("Scan with VirusTotal", "Skenovat s VirusTotal");
            czech.Add("Added to content menu", "Přidáno do menu");
            czech.Add("Removed from content menu", "Odebráno z menu");

            czech.Add("About", "O programu");
            czech.Add("API key", "API klíč");
            czech.Add("To get API key log-in on VirusTotal and under account select \"My API key\"", "K získání API kíče jděte na stránku VirusTotal a pod svým \núčtem vyberte \"My API key\"");
            czech.Add("General", "Obecné");
            czech.Add("Other", "Další");
            czech.Add("Use dark theme", "Používat \ntmavý motiv");
            czech.Add("Add to content menu", "Přidat do menu");
            czech.Add("Remove from content menu", "Odebrat z menu");
            czech.Add("Save settings", "Uložit nastavení");
            czech.Add("Open settings file", "Otevřít soubor nastavení");
            czech.Add("Restart app to apply settings", "Restartujte aplikaci k uplatnění změn");
            czech.Add("Language", "Jazyk");

            czech.Add("Settings", "Nastavení");

            /*
              ___            _           
             | _ \_  _ _____(_)__ _ _ _  
             |   / || (_-<_-< / _` | ' \ 
             |_|_\\_,_/__/__/_\__,_|_||_|
           
            */
            // Google Translate is not a best metod to translate but it was easy so cmon
            // Please some russian guy fix it
            russian = new Dictionary<string, string>();

            russian.Add("Checking...", "Проверка ...");
            russian.Add("Uploading...", "Загрузка ...");
            russian.Add("Drag file here", "Перетащите файл здесь");
            russian.Add("Fatal Error", "Фатальная ошибка");
            russian.Add("Error", "ошибка");
            russian.Add("This file was already scanned on ", "Этот файл уже был проверен на");
            russian.Add("Do you want to view results of scan or rescan file ? (\"Yes\" to view, \"No\" to rescan)", "Вы хотите просмотреть результаты сканирования или повторного сканирования файла");
            russian.Add("File is already in database", "Файл уже находится в базе данных");
            russian.Add("VirusTotal response: ", "VirusTotal response:");
            russian.Add(" Program error: ", "  Ошибка программы:");
            russian.Add("Settings saved!", "Настройки сохранены!");
            russian.Add("Yeah!", "Да!");
            russian.Add("Scan with VirusTotal", "Сканирование с помощью VirusTotal");
            russian.Add("Added to content menu", "Добавлено в меню содержимого");
            russian.Add("Removed from content menu", "Удалено из меню содержимого");
            russian.Add("About", "Около");
            russian.Add("API key", "Ключ API");
            russian.Add("To get API key log-in on VirusTotal and under account select \"My API key\"", "Чтобы получить доступ к API-ключам в VirusTotal и под учетной записью, выберите \"My API key\"");
            russian.Add("General", "Генеральная");
            russian.Add("Other", "Другие");
            russian.Add("Use dark theme", "Использовать темную тему");
            russian.Add("Add to content menu", "Добавить в контекстное меню");
            russian.Add("Remove from content menu", "Удалить из меню содержимого");
            russian.Add("Save settings", "Сохранить настройки");
            russian.Add("Open settings file", "Открыть файл настроек");
            russian.Add("Restart app to apply settings", "Перезапустить приложение для применения настроек");
            russian.Add("Language", "язык");
            russian.Add("Settings", "настройки");

        }

        public string GetString(string text)
        {
            string language = "English";
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "settings.txt"))
            {
                try
                {
                    string data = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "settings.txt");
                    string[] arrayd = data.Split(':');
                    language = arrayd[2];
                } catch (Exception error)
                {

                }
            }
            
            if (language == "English")
            {
                return english[text];
            }
            if (language == "Czech")
            {
                if (!czech.ContainsKey(text)) return english[text];
                return czech[text];
            }
            if (language == "Russian")
            {
                if (!russian.ContainsKey(text)) return english[text];
                return russian[text];
            }

            return "No language set!";
        }
    }
}
