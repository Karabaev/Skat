using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProj
{
    using System.Collections.Generic;
    using System.Linq;
    using FTPDownloader.BusinessLogicLayer;
    using FTPDownloader.DataAccessLayer;

    [TestClass]
    public class DALTest
    {
        public DALTest()
        {
            logger = new Logger();
            repository = new Repository(logger);
            SettingsContainer.Settings.LogFileName = "Log.log";
            SettingsContainer.Settings.DataFileName = "Data.json";
        }

        [TestMethod]
        public void ReposAddTest()
        {
            FTPAccessData newRecord = new FTPAccessData(0, "n1", "n1", "n1", "n1", "n1");  
            Assert.IsTrue(this.repository.Add(newRecord));
        }

        [TestMethod]
        public void ReposClearTest()
        {
            repository.Clear();
            Console.WriteLine(repository.jsonData);
            repository.GetData();
            Console.WriteLine(repository.jsonData);
            Assert.IsTrue(repository.AccessDataList.Count == 0);
        }

        [TestMethod]
        public void ReposGetDataTest()
        {
            List<FTPAccessData> dataList = new List<FTPAccessData>();
            dataList.Add(new FTPAccessData(0, "n1", "n1", "n1", "n1", "n1"));
            dataList.Add(new FTPAccessData(1, "n1", "n1", "n1", "n1", "n1"));
            dataList.Add(new FTPAccessData(2, "n1", "n1", "n1", "n1", "n1"));
            dataList.Add(new FTPAccessData(3, "n1", "n1", "n1", "n1", "n1"));
            dataList.Add(new FTPAccessData(4, "n1", "n1", "n1", "n1", "n1"));

            foreach (var item in dataList)
            {
                this.repository.Add(item);
                Console.WriteLine(repository.jsonData);
            }

            this.repository.GetData();
            Assert.IsTrue(dataList.All(this.repository.AccessDataList.Contains));
        }

        [TestMethod]
        public void ReposRemoveTest()
        {
            //FTPAccessData newRecord = new FTPAccessData(0, "n1", "n1", "n1", "n1", "n1");
            
            //Assert.IsTrue(repository.Add(newRecord));
        }

        private readonly Repository repository;
        private readonly Logger logger;
    }
}
