namespace FTPDownloader.BusinessLogicLayer
{
    using System.Text;
    using Newtonsoft.Json;
    using System.IO;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Хранилище настроек.
    /// </summary>
    public static class SettingsContainer
    {
        private const string SettingsFileName = "Settings.json";
        /// <summary>
        /// Инициализирует объект в памяти. Инициализирует логгер, читает настройки из файла.
        /// </summary>
        static SettingsContainer()
        {
            Load();       
        }

        /// <summary>
        /// Настройки. Get - читает настройки из файла.
        /// </summary>
        public static SettingProps Settings { get; private set; }

        /// <summary>
        /// Записать json в файл.
        /// </summary>
        /// <returns></returns>
        public static bool Save()
        {
            try
            {
                File.WriteAllText(SettingsFileName, JsonConvert.SerializeObject(Settings));
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(string.Format("{0}, {1}", ex.StackTrace, ex.Message), "Error to save settings.");
                return false;
            }
        }

        /// <summary>
        /// Читать json из файла.
        /// </summary>
        /// <returns></returns>
        public static bool Load()
        {
            try
            {
                Settings = JsonConvert.DeserializeObject <SettingProps>(File.ReadAllText(SettingsFileName));
            }
            catch(FileNotFoundException)
            {
                Settings = new SettingProps();
                Save();
            }
            catch(IOException)
            {
                Settings = new SettingProps();
                Save();
            }

            return Settings != null;
        }
    }
}
