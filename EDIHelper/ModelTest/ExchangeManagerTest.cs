using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTest
{
    using DomainModel.Logic;
    [TestClass]
    public class ExchangeManagerTest
    {
        [TestMethod]
        public void UnLoadAllTest()
        {
            ExchangeManager manager = new ExchangeManager("", "TestUpload.xml", @"C:\Темп\1C\Exchange", new Logger("Test log.log", ""));
            manager.UnloadAll();
        }
    }
}
