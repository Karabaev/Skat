using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTest
{
    using DomainModel.Repository;
    using DomainModel.Model;
    using DomainModel.Logic;
    using DomainModel.Logic.XML;
    using System.IO;
    using System.Collections.Generic;

    [TestClass]
    public class WBServiceTest
    {
        [TestMethod]
        public void AddRecord()
        {
            WBService wBService = new WBService(new Logger("Log.log", "Testing"));

            List<byte> bytes = new List<byte>();
            var bytesAr = File.ReadAllBytes("Test.xml");

            foreach (var item in bytesAr)
            {
                bytes.Add(item);
            }

            XMLConverter converter = new XMLConverter(bytes, new Logger("Log.log", "Testing"));
            Assert.IsTrue(wBService.AddRecord(converter.GetWaybill()));
        }
    }
}
