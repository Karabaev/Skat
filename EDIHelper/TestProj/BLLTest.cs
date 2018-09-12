using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProj
{
    using FTPDownloader.BusinessLogicLayer;
    using FTPDownloader.DataAccessLayer;
    using Newtonsoft.Json;
    [TestClass]
    public class BLLTest
    {
        public BLLTest()
        { 
            logger = new Logger(SettingsContainer.Settings.LogFileFullPath);
        }
          
        [TestMethod]
        public void LoggerTest()
        {
            logger.WriteLog("Тестовый лог", LogTypes.INFO);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetFileListTest()
        {
            FTPManager fTPManager = new FTPManager("ftp://192.168.5.5");
            FTPAccessData accessData = new FTPAccessData(0, "Polikon", "111", "polikon", "4BLRGC3XP48TP4", @"C:\Доработки\EDIHelper\TestProj\bin\Debug\Waybills");
            var result = fTPManager.GetFileList(accessData);

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " " + item.Type);
            }

        }

        [TestMethod]
        public void DownloadTest()
        {
            FTPManager fTPManager = new FTPManager("ftp://192.168.5.5");
            FTPAccessData accessData = new FTPAccessData(0, "Polikon", "111", "polikon", "4BLRGC3XP48TP4", @"C:\Доработки\EDIHelper\TestProj\bin\Debug\Waybills");
            fTPManager.DownloadFiles(accessData);
        }

        [TestMethod]
        public void SettingsLoadTest()
        {
            Console.WriteLine(SettingsContainer.Load());
        }

        [TestMethod]
        public void SettingsSaveTest()
        {
            SettingsContainer.Save();
        }

        private readonly Logger logger;
    }
}
