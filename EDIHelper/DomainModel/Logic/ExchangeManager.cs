namespace DomainModel.Logic
{
    using System;
    using System.IO;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using Repository;
    using XML;

    /// <summary>
    /// Менеджер обмена.
    /// </summary>
    public class ExchangeManager
    {
        /// <summary>
        /// Инициализирует объект в памяти.
        /// </summary>
        /// <param name="downFileName">Локальное имя файла загрузки.</param>
        /// <param name="upFileName">Локальное имя файла выгрузки.</param>
        /// <param name="exchFolder">Папка обмена.</param>
        /// <param name="logger">Логгер.</param>
        public ExchangeManager(string downFileName, string upFileName, string exchFolder, Logger logger)
        {
            this.DownloadFileName = downFileName;
            this.UploadFileName = upFileName;
            this.ExchangeFolder = exchFolder;
            this.Logger = logger;
            this.ClientRepository = new ClientRepository();
            this.SupplierRepository = new SupplierRepository();
            this.TradeObjectRepository = new TradeObjectRepository();
        }

        /// <summary>
        /// Загрузить все справочники из файла загрузки.
        /// </summary>
        public void LoadAll()
        {
            this.Logger.WriteLog("Checking download file");
            List<byte> bytes = new List<byte>();
            byte[] bytesAr = null;
            try
            {
                bytesAr = File.ReadAllBytes(Path.Combine(this.ExchangeFolder, this.DownloadFileName));
            }
            catch(FileNotFoundException ex)
            {
                this.Logger.WriteLog("Download file not found");
                throw ex;
            }
            this.Logger.WriteLog("Download file found");

            foreach (var item in bytesAr)
            {
                bytes.Add(item);
            }

            XMLConverter converter = new XMLConverter(bytes, this.Logger);
            this.LoadClients(converter);
            this.LoadSuppliers(converter);
            this.LoadTradeObjects(converter);
            File.Move(Path.Combine(this.ExchangeFolder, this.DownloadFileName), Path.Combine(this.ExchangeFolder, this.DownloadFileName + DateTime.Now.ToString("ddMMyyyy_hhmmss")));
        }

        /// <summary>
        /// Записать в базу клиентов.
        /// </summary>
        /// <param name="converter"></param>
        private void LoadClients(XMLConverter converter)
        {
            this.Logger.WriteLog("Downloading clients");
            try
            {
                foreach (var item in converter.GetClients())
                {
                    this.ClientRepository.AddOrUpdateEntity(item);
                }
            }
            catch(Exception ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error downloading clients", ex.Source, ex.Message, ex.StackTrace), LogTypes.WARNING);
            }

        }

        /// <summary>
        /// Записать в базу поставщиков.
        /// </summary>
        /// <param name="converter"></param>
        private void LoadSuppliers(XMLConverter converter)
        {
            this.Logger.WriteLog("Downloading suppliers");
            try
            {
                foreach (var item in converter.GetSuppliers())
                {
                    this.SupplierRepository.AddOrUpdateEntity(item);
                }
            }
            catch (Exception ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error downloading suppliers", ex.Source, ex.Message, ex.StackTrace), LogTypes.WARNING);
            }
        }

        /// <summary>
        /// Записать в базу торговые объекты.
        /// </summary>
        /// <param name="converter"></param>
        private void LoadTradeObjects(XMLConverter converter)
        {
            this.Logger.WriteLog("Downloading trade objects");
            try
            {
                foreach (var item in converter.GetTradeObjects())
                {
                    this.TradeObjectRepository.AddOrUpdateEntity(item);
                }
            }
            catch (Exception ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error downloading trade objects", ex.Source, ex.Message, ex.StackTrace), LogTypes.WARNING);
            }
        }

        public void UnloadAll()
        {
            try
            {
                XMLConverter converter = new XMLConverter(this.Logger);
                converter.GetXmlAll().Save(Path.Combine(this.ExchangeFolder, this.UploadFileName));
            }
            catch(UnauthorizedAccessException ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}, {2}: {3}", "Not enough permissions to create a file", ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
            }      
        }

        public void UnloadToPeriod(DateTime begin, DateTime end)
        {
            try
            {
                XMLConverter converter = new XMLConverter(this.Logger);
                converter.GetXmlAllToPeriod(begin, end).Save(Path.Combine(this.ExchangeFolder, this.UploadFileName));
            }
            catch(UnauthorizedAccessException ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}, {2}: {3}", "Not enough permissions to create a file", ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
            }
        }

        /// <summary>
        /// Логгер.
        /// </summary>
        private Logger Logger { get; set; }
        /// <summary>
        /// Локальное имя файла загрузки.
        /// </summary>
        private string DownloadFileName { get; set; }
        /// <summary>
        /// Локальное имя файла выгрузки.
        /// </summary>
        private string UploadFileName { get; set; }
        /// <summary>
        /// Папка обмена.
        /// </summary>
        private string ExchangeFolder { get; set; }
        /// <summary>
        /// Репозиторий клиентов.
        /// </summary>
        private ClientRepository ClientRepository { get; set; }
        /// <summary>
        /// Репозиторий торговых объектов.
        /// </summary>
        private TradeObjectRepository TradeObjectRepository { get; set; }
        /// <summary>
        /// Репозиторий поставщиков.
        /// </summary>
        private SupplierRepository SupplierRepository { get; set; }
    }
}
