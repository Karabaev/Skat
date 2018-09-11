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

    [TestClass]
    public class BLLTest
    {
        public BLLTest()
        {
            logger = new Logger();
            SettingsContainer.SettingsInit(logger);
            SettingsContainer.Settings.LogFileName = "Log.log";
            SettingsContainer.Settings.DataFileName = "Data.json";
        }
          
        [TestMethod]
        public void LoggerTest()
        {
            logger.WriteLog("Тестовый лог", LogTypes.INFO);
            Assert.IsTrue(true);
        }

        private readonly Logger logger;
    }
}
