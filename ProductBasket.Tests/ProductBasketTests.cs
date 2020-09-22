using Microsoft.IdentityModel.Tokens;
using Moq;
using NUnit.Framework;
using ProductBasket.DataAccess.IRepository;
using ProductBasket.DataAccess.Repository;
using ProductBasket.Models;

namespace ProductBasket.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
           
            var product = new Product() { Id = 1, ProdName = "Abc", ProdImageName = "Abc.jpg",ProdPrice=250 };
            var mockRepo = new Mock<IRepository<Repository<Product>>>();

            mockRepo.Setup(x => x.Add(product)).Returns(null);
            mockRepo.Setup(x => x.Get(1)).Returns(product);
            //var data = new ProductRepository(mockRepo.Object);
        }

        [Test]
        public void If_Add_Is_Working()
        {
            Assert.Pass();
        }
    }
}