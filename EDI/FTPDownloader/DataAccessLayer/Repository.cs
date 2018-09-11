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
        /// Лист данных.
        /// </summary>
      //  private List<FTPAccessData> accessDataList;
        /// <summary>
        /// json текст.
        /// </summary>
        public string jsonData;
        /// <summary>
        /// Логгер.
        /// </summary>
        private Logger logger;

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
        public List<FTPAccessData> GetData()
        {
            try
            {
                using (FileStream stream = File.OpenRead(SettingsContainer.Settings.DataFileName))
                {
                    List<FTPAccessData> result = null;
                    byte[] byteArray = new byte[stream.Length];
                    stream.Read(byteArray, 0, byteArray.Length);
                    this.jsonData = Encoding.Default.GetString(byteArray);
                    result = JsonConvert.DeserializeObject<List<FTPAccessData>>(jsonData);
                    this.logger.WriteLog(string.Format("{0} records are loaded", result?.Count));
                    return result;
                }
            }
            catch(IOException ex)
            {
                this.logger.WriteLog(ex.StackTrace, LogTypes.ERROR);
                this.logger.WriteLog(ex.Message, LogTypes.ERROR);
                return null;
            }
        }

        /// <summary>
        /// Сохранить данные в файл.
        /// </summary>
        /// <returns>true, в случае успешной записи иначе false.</returns>
        public bool SaveChanges()
        {
            try
            {
                using (FileStream stream = new FileStream(SettingsContainer.Settings.DataFileName, FileMode.Truncate))
                {
                    jsonData = JsonConvert.SerializeObject(AccessDataList);
                    byte[] array = Encoding.Default.GetBytes(jsonData);
                    stream.Write(array, 0, array.Length);
                    this.logger.WriteLog(string.Format("All data was saved."));
                    return true;
                }
            }
            catch(IOException ex)
            {
                this.logger.WriteLog(ex.StackTrace, LogTypes.ERROR);
                this.logger.WriteLog(ex.Message, LogTypes.ERROR);
                return false;
            }
        }

        /// <summary>
        /// Лист данных.
        /// </summary>
        public List<FTPAccessData> AccessDataList { get; private set; }
    }
}
