﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTest
{
    using DomainModel.Model;
    using DomainModel.Repository;

    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ReposAddTest()
        {
            ClientRepository repos = new ClientRepository();
            Client client = new Client { Name = "c1", GLN = "c1", INN = "c1", KPP = "c1" };
            Assert.IsTrue(repos.AddEntity(client));
        }

        [TestMethod]
        public void ReposGetEntityTest()
        {
            ClientRepository repos = new ClientRepository();
            Client client = repos.GetEntity(1);
            Console.WriteLine(client);
        }
    }
}
