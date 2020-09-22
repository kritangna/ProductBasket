using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ProductBasket.DataAccess.IRepository;
using ProductBasket.DataAccess.Repository;
using ProductBasket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBasket.Tests
{
    [TestClass]
    public class PTest
    {
        

        [TestMethod]
        public void TestSetup()
        {

            var product = new Product() { Id = 1, ProdName = "Abc", ProdImageName = "Abc.jpg", ProdPrice = 250 };
            var mockRepo = new Mock<Repository<Product>>();
            mockRepo.Setup(x => x.Add(product));
           // mockRepo.Setup(x => x.GetStr()).Returns("shivani");
            var prodRepo = new RepoTest(mockRepo.Object);
            // var data = new Repository<Product>(mockRepo.Object);
            var result = prodRepo.CallGetStr(mockRepo.Object);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, "shivani");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, "Nikita");

        }
        [Test]
        public void TestSetup3()
        {

            var newObj = new Repository<Product>();
            var product = new Product() { Id = 2, ProdName = "Abc", ProdImageName = "Abc.jpg", ProdPrice = 250 };
            var str= newObj.GetStr(1);


            var mockRepo = new Mock<Repository<Product>>();
            //  mockRepo.Setup(x => x.Add(product));
            //mockRepo.Setup(x => x.GetStr(It.IsAny<int>())).Returns("shivani");
            mockRepo.Setup(x => x.Get(It.IsAny<int>())).Returns(product);
            mockRepo.Setup(x => x.Add(It.IsAny<Product>())).Verifiable();
            mockRepo.VerifyAll();
            //mockRepo.Setup(x => x.GetStr(It.IsAny<Func<void>>()).Returns("Shivani");
            var prodRepo = new RepoTest(mockRepo.Object);
            
            var result = prodRepo.CallGet(mockRepo.Object,1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, product);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(str, "shivani");

            //mockRepo.SetupProperty(x=>x.)
        }

    }
}
