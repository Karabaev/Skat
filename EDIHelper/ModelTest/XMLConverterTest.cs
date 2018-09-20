using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTest
{
    using System.Collections.Generic;
    using DomainModel.Logic.XML;
    using DomainModel.Model;
    using DomainModel.Logic;
    using System.IO;

    [TestClass]
    public class XMLConverterTest
    {
        /// <summary>
        /// тест метода XMLConverter.GetWaybill()
        /// </summary>
        [TestMethod]
        public void GetWayBillTest()
        {
            List<byte> bytes = new List<byte>();
            var bytesAr = File.ReadAllBytes("Test.xml");

            foreach (var item in bytesAr)
            {
                bytes.Add(item);
            }

            XMLConverter converter = new XMLConverter(bytes, new Logger("Log.log", "Testing"));

            Waybill waybill = converter.GetWaybill();
            Waybill expectedWayBill = new Waybill
            {
                Number = "ТКУ8226918",
                ClientID = 1,
                DocumentDate = new DateTime(2018, 8, 30),
                DownloadDate = waybill.DownloadDate,
                SupplierID = 1
            };

            Assert.IsTrue(expectedWayBill.LikeAs(waybill));
        }

        
        [TestMethod]
        public void GetWayBillSupplierNotExistTest()
        {
            List<byte> bytes = new List<byte>();
            var bytesAr = File.ReadAllBytes("Test (2).xml");

            foreach (var item in bytesAr)
            {
                bytes.Add(item);
            }

            XMLConverter converter = new XMLConverter(bytes, new Logger("Log.log", "Testing"));

            Waybill waybill = converter.GetWaybill();
            Waybill expectedWayBill = new Waybill
            {
                Number = "ТКУ8226918",
                ClientID = 1,
                DocumentDate = new DateTime(2018, 8, 30),
                DownloadDate = waybill.DownloadDate,
                SupplierID = 1
            };

            Assert.IsTrue(expectedWayBill.LikeAs(waybill));
        }
    }
}
