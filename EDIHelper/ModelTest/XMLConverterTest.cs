using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTest
{
    using System.Collections.Generic;
    using DomainModel.Logic.XML;
    using DomainModel.Model;
    using DomainModel.Logic;
    using System.IO;
    using System.Linq;

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

        [TestMethod]
        public void GetClientsTest()
        {
            List<Client> expectedClients = new List<Client>();
            expectedClients.Add(new Client { Name = "Поликарпов", GLN = "54525432523524", INN = "1841040275", KPP = "123456789" });
            expectedClients.Add(new Client { Name = "Поликон", GLN = "131234441424141", INN = "1841040275", KPP = "123456789" });

            List<byte> bytes = new List<byte>();
            var bytesAr = File.ReadAllBytes("TestExchange.xml");

            foreach (var item in bytesAr)
            {
                bytes.Add(item);
            }

            XMLConverter converter = new XMLConverter(bytes, new Logger("Log.log", "Testing"));

            List<Client> gettedClients = converter.GetClients();

            if(expectedClients.Count != gettedClients.Count)
            {
                Assert.Fail("Количество клиентов не совпадает");
            }

            Assert.IsTrue(expectedClients.All(gettedClients.Contains));
        }

        [TestMethod]
        public void GetSuppliersTest()
        {
            List<Supplier> expecterSuppliers = new List<Supplier>();
            expecterSuppliers.Add(new Supplier { Name = "Комос", GLN = "2313214214214", INN = "1234567890", KPP = "12345678", IsRoaming = false });
            expecterSuppliers.Add(new Supplier { Name = "Не комос", GLN = "2424422", INN = "123456355", KPP = "123548", IsRoaming = true });

            List<byte> bytes = new List<byte>();
            var bytesAr = File.ReadAllBytes("TestExchange.xml");

            foreach (var item in bytesAr)
            {
                bytes.Add(item);
            }

            XMLConverter converter = new XMLConverter(bytes, new Logger("Log.log", "Testing"));

            List<Supplier> gettedSuppliers = converter.GetSuppliers();

            if (expecterSuppliers.Count != gettedSuppliers.Count)
            {
                Assert.Fail("Количество клиентов не совпадает");
            }

            foreach (var item in expecterSuppliers)
                Console.WriteLine(item);
            foreach (var item in gettedSuppliers)
                Console.WriteLine(item);
            Assert.IsTrue(expecterSuppliers.All(gettedSuppliers.Contains));
        }
    }
}
