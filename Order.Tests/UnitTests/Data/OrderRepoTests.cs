using System;
using System.Collections.Generic;
using System.Linq;
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
    public class OrderRepoTests
    {
        [Test]
        public void EnsureDBContextIsRequired()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new OrderRepo(null));
        }

        [Test]
        public void CanCreateInstanceOfCustomerRepo()
        {
            OrderDbContext dbContext = DataContextCreator.GetContext();

            OrderRepo sut = new OrderRepo(dbContext);
            Assert.IsNotNull(sut);
        }

        [Test]
        public void CanSaveANewOrder()
        {
            OrderDbContext dbContext = DataContextCreator.GetContext();

            Product productTestData = new Product()
            {
                ProductName = "name",
                PricePerItem = 12,
                AverageCustomerRating = 10
            };
            Customer customerTestData = new Customer()
            {
                CustomerName = "name",
                AddressLine1 = "l1",
                AddressLine2 = "l2",
                City = "c",
                State = "CA",
                Zip = "92805",
                Country = "USA"
            };

            dbContext.Customers.Add(customerTestData);
            dbContext.Products.Add(productTestData);
            dbContext.SaveChanges();

            DateTime orderDateTime = DateTime.UtcNow;
            int quanityOrdered = 1;
            decimal orderTotal = (decimal)34.56;

            OrderRepo sut = new OrderRepo(dbContext);

            Task task = sut.SaveNewOrderAsync(productTestData, customerTestData, orderDateTime, quanityOrdered, orderTotal);
            Task.WaitAll(task);

            if (task.IsFaulted)
            {
                throw task.Exception;
            }

            Assert.GreaterOrEqual(1,dbContext.Orders.Count());
            Order.Data.Ef.Entities.Order orderFromStorage = dbContext.Orders.FirstOrDefault();
            Assert.AreEqual(productTestData.ProductId,orderFromStorage.Product.ProductId);
            Assert.AreEqual(customerTestData.CustomerId,orderFromStorage.Customer.CustomerId);
            Assert.AreEqual(orderDateTime,orderFromStorage.OrderDate);
            Assert.AreEqual(quanityOrdered,orderFromStorage.Quantity);
            Assert.AreEqual(orderTotal,orderFromStorage.PricePaid);
            Assert.AreEqual(DateTime.MinValue, orderFromStorage.ShippedDate);

        }

        [Test]
        public void CanGetThePendingOrders()
        {
            OrderDbContext dbContext = DataContextCreator.GetContext();

            Product productTestData = new Product()
            {
                ProductName = "name",
                PricePerItem = 12,
                AverageCustomerRating = 10
            };
            Customer customerTestData = new Customer()
            {
                CustomerName = "name",
                AddressLine1 = "l1",
                AddressLine2 = "l2",
                City = "c",
                State = "CA",
                Zip = "92805",
                Country = "USA"
            };

            dbContext.Customers.Add(customerTestData);
            dbContext.Products.Add(productTestData);

            DateTime orderDateTime = DateTime.UtcNow;
            int quanityOrdered = 1;
            decimal orderTotal = (decimal)34.56;

            OrderRepo sut = new OrderRepo(dbContext);

            Task task = sut.SaveNewOrderAsync(productTestData, customerTestData, orderDateTime, quanityOrdered, orderTotal);
            Task.WaitAll(task);

            if (task.IsFaulted)
            {
                throw task.Exception;
            }

            Task<IEnumerable<IPendingOrder>> taskResults = sut.GetPendingOrdersAsync();
            Task.WaitAll(task);
            if (task.IsFaulted)
            {
                throw task.Exception;
            }

            IEnumerable<IPendingOrder> result = taskResults.Result;
            Assert.GreaterOrEqual(1,result.Count());
        }
    }
}