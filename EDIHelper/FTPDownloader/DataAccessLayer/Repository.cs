namespace FTPDownloader.DataAccessLayer
{
    using System.Collections.Generic;
    using System.Text;
    using BusinessLogicLayer;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Репозиторий данных.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// json текст.
        /// </summary>
        public string jsonData;
        /// <summary>
        /// Логгер.
        /// </summary>
        private Logger logger;

        public static int LastID;
        /// <summary>
        /// Инициализирует новый объект в памяти.
        /// </summary>
        /// <param name="logger"></param>
        public Repository(Logger logger)
        {
            this.AccessDataList = new List<FTPAccessData>();
            this.jsonData = string.Empty;
            this.logger = logger;
            this.GetData();
        }

        /// <summary>
        /// Добавить в лист новые данные.
        /// </summary>
        /// <param name="newData">Новые данные.</param>
        /// <returns>true, в случае успешной записи иначе false.</returns>
        public bool Add(FTPAccessData newData)
        {
            if(newData == null)
            {
                this.logger.WriteLog("Error adding record", LogTypes.WARNING);
                return false;
            }

            this.AccessDataList.Add(newData);
            this.logger.WriteLog("The entry was successfully added to data list");
            return this.SaveChanges();
        }

        public bool Remove(int id)
        { 
            bool result = this.AccessDataList.Remove(this.AccessDataList.Where(d => d.ID == id).FirstOrDefault()) 
                            && this.SaveChanges();
            return result;
        }

        public bool Clear()
        {
            this.AccessDataList.Clear();
            return this.SaveChanges();
        }

        /// <summary>
        /// Считать все данные из файла.
        /// </summary>
        /// <returns>true, в случае успешной записи иначе false.</returns>
        public bool GetData()
        {
            try
            {
                this.AccessDataList = JsonConvert.DeserializeObject<List<FTPAccessData>>(File.ReadAllText(SettingsContainer.Settings.DataFileFullName));
                this.logger.WriteLog("All data was loaded.");
            }
            catch(FileNotFoundException ex)
            {
                this.logger.WriteLog(ex.StackTrace);
                this.logger.WriteLog(ex.Message);
                this.AccessDataList = new List<FTPAccessData>();
                this.SaveChanges();
            }
            catch(IOException ex1)
            {
                this.logger.WriteLog(ex1.StackTrace, LogTypes.ERROR);
                this.logger.WriteLog(ex1.Message, LogTypes.ERROR);
                this.AccessDataList = null;
            }
            catch(JsonException ex2)
            {
                this.logger.WriteLog(ex2.StackTrace);
                this.logger.WriteLog(ex2.Message);
                this.AccessDataList = new List<FTPAccessData>();
                this.SaveChanges();
            }

            return this.AccessDataList != null;
        }

        /// <summary>
        /// Сохранить данные в файл.
        /// </summary>
        /// <returns>true, в случае успешной записи иначе false.</returns>
        public bool SaveChanges()
        {
            try
            {
                File.WriteAllText(SettingsContainer.Settings.DataFileFullName, JsonConvert.SerializeObject(this.AccessDataList));
                this.logger.WriteLog(string.Format("All data was saved."));
                return true;
            }
            catch (IOException ex)
            {
                this.logger.WriteLog(ex.StackTrace, LogTypes.ERROR);
                this.logger.WriteLog(ex.Message, LogTypes.ERROR);
                return false;
            }
            catch (JsonException ex1)
            {
                this.logger.WriteLog(ex1.StackTrace);
                this.logger.WriteLog(ex1.Message);
                return false;
            }
        }

        /// <summary>
        /// Лист данных.
        /// </summary>
        public List<FTPAccessData> AccessDataList { get; private set; }
    }
}
