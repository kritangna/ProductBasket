using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ProductBasket.DataAccess.Data;
using ProductBasket.DataAccess.IRepository;
using ProductBasket.DataAccess.Repository;
using ProductBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace ProductBasket.Tests
{
    [TestFixture]
    public class PTest
    {


        [SetUp]
        public void TestSetup()
        {

            // var product = new Product() { Id = 1, ProdName = "Abc", ProdImageName = "Abc.jpg", ProdPrice = 250 };
            // var mockRepo = new Mock<Repository<Product>>();
            // mockRepo.Setup(x => x.Add(product));
            //// mockRepo.Setup(x => x.GetStr()).Returns("shivani");
            // var prodRepo = new RepoTest(mockRepo.Object);
            // // var data = new Repository<Product>(mockRepo.Object);
            // var result = prodRepo.CallGetStr(mockRepo.Object);
            // //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, "shivani");
            // Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, "Nikita");

        }
        [Test]
        public async Task Test_If_The_Product_Is_Added_To_The_Db()
        {
            //Setup
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("ProdBasket");
            var appdbcon = new ApplicationDbContext(optionBuilder.Options);

            //Arrange
            var product = new Product() { Id = 2, ProdName = "Abc", ProdImageName = "Abc.jpg", ProdPrice = 250 };
            //var str= newObj.GetStr(1);

            //var mockRepo = new Mock<IRepository<Repository<Product>>>();
            //var mockRepo = new Mock<Repository<Product>>();  //nsubstitue
            //  mockRepo.Setup(x => x.Add(product));
            //mockRepo.Setup(x => x.GetStr(It.IsAny<int>())).Returns("shivani");
            //mockRepo.Setup(x => x.Get(It.IsAny<int>())).Returns(product);
            // mockRepo.Setup(x => x.Add(It.IsAny<Product>())).Verifiable();
            //mockRepo.VerifyAll();
            //mockRepo.Setup(x => x.GetStr(It.IsAny<Func<void>>()).Returns("Shivani");
            var prodRepo = new Repository<Product>(appdbcon);

            //Act
            prodRepo.Add(product);

            //Assert
            var result = await appdbcon.Products.FirstOrDefaultAsync();
            Assert.AreEqual(result.ProdName, product.ProdName);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(str, "shivani");
            Assert.AreSame(product, result);
            //mockRepo.SetupProperty(x=>x.)
        }

        [Test]
        public void Test_If_Get_Product_Is_Getting_Product_From_The_Db()
        {
            //Setup
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("ProdBasket");
            var appdbcon = new ApplicationDbContext(optionBuilder.Options);

            //Arrange
            var product = new Product() { Id = 2, ProdName = "Abc", ProdImageName = "Abc.jpg", ProdPrice = 250 };
            appdbcon.Products.Add(product); //Inbuilt
            appdbcon.SaveChanges();


            appdbcon.ChangeTracker.Entries().ToList().ForEach(x => x.State = EntityState.Detached);
            var prodRepo = new Repository<Product>(appdbcon);
            //Act
            var result = prodRepo.Get(product.Id);

            //Assert
            //var result = await appdbcon.Products.FirstAsync();
            Assert.IsNotNull(result.Id);

        }
        [Test]
        public void Test_If_Product_Is_Removed_From_The_Table_On_Calling_Remove_Method()
        {
            //Setup
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("ProdBasket");
            var appDbCon = new ApplicationDbContext(optionsBuilder.Options);

            //Arrange
            var product = new Product() { Id = 1, ProdName = "Prod_one", ProdImageName = "Prod_One.jpg", ProdPrice = 450 };
            appDbCon.Products.Add(product);
            appDbCon.SaveChanges();

            //Act
            var repo = new Repository<Product>(appDbCon);
            repo.Remove(product.Id);
            var result = appDbCon.Products.FirstOrDefault();

            //Assert
            Assert.IsNull(result);
        }

    }
}
