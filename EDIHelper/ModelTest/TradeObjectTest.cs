using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTest
{
    using System.Collections.Generic;
    using DomainModel.Model;
    using DomainModel.Repository;
    [TestClass]
    public class TradeObjectTest
    {
        [TestMethod]
        public void AddTest()
        {
            TradeObjectRepository repo = new TradeObjectRepository();
            Assert.IsTrue(repo.AddEntity(new TradeObject { ID = 1, Address = "to1", GLN = "to1", Name = "to2" }));
        }

        [TestMethod]
        public void GetAllTest()
        {
            TradeObjectRepository repo = new TradeObjectRepository();
            List<TradeObject> objects = repo.GetAllEntities();
            foreach (var item in objects)
            {
                Console.WriteLine(item.ToString());
            }
        }

        [TestMethod]
        public void GetEntityTest()
        {
            TradeObjectRepository repo = new TradeObjectRepository();
            Console.WriteLine(repo.GetEntity(2)?.ToString());
        }
    }
}
