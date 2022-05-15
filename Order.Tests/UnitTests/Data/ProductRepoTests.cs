using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Order.Data.Ef;
using Order.Data.Ef.Entities;
using Order.Data.Ef.Repos;
using Order.Glue.Interfaces.DTOs;
// ReSharper disable PossibleNullReferenceException
// ReSharper disable InconsistentNaming

namespace Order.Tests.UnitTests.Data
{
    [TestFixture]
    public class ProductRepoTests
    {
        [Test]
        public void EnsureDBContextIsRequired()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new ProductRepo(null));
        }

        [Test]
        public void CanCreateInstanceOfCustomerRepo()
        {
            OrderDbContext dbContext = DataContextCreator.GetContext();

            ProductRepo sut = new ProductRepo(dbContext);
            Assert.IsNotNull(sut);
        }


        [Test]
        public void CanGetAProductFromDataStore()
        {
            OrderDbContext dbContext = DataContextCreator.GetContext();

            Product testData = new Product()
            {
                ProductName = "name",
                PricePerItem = 12,
                AverageCustomerRating = 10
            };

            dbContext.Products.Add(testData);
            dbContext.SaveChanges();

            ProductRepo sut = new ProductRepo(dbContext);

            Task<IProduct> task = sut.GetProductAsync(testData.ProductId);
            Task.WaitAll(task);
            if (task.IsFaulted)
            {
                throw task.Exception;
            }

            IProduct result = task.Result;
            Assert.AreEqual(testData.ProductName, result.ProductName);
            Assert.AreEqual(testData.PricePerItem, result.PricePerItem);
            Assert.AreEqual(testData.AverageCustomerRating, result.AverageCustomerRating);
        }
    }
}