using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Order.Data.Ef;
using Order.Data.Ef.Entities;
using Order.Data.Ef.Repos;
using Order.Glue.Interfaces.DTOs;
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException

namespace Order.Tests.UnitTests.Data
{
    [TestFixture]
    public class CustomerRepoTests
    {
        [Test]
        public void EnsureDBContextIsRequired()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new CustomerRepo(null));
        }

        [Test]
        public void CanCreateInstanceOfCustomerRepo()
        {
            OrderDbContext dbContext = DataContextCreator.GetContext();

            CustomerRepo sut = new CustomerRepo(dbContext);
            Assert.IsNotNull(sut);
        }

        [Test]
        public void CanGetACustomerFromDataStore()
        {
            OrderDbContext dbContext = DataContextCreator.GetContext();

            Customer testData = new Customer()
            {
                CustomerName = "name",
                AddressLine1 = "l1",
                AddressLine2 = "l2",
                City = "c",
                State = "CA",
                Zip = "92805",
                Country = "USA"
            };

            dbContext.Customers.Add(testData);
            dbContext.SaveChanges();

            CustomerRepo sut = new CustomerRepo(dbContext);

            Task<ICustomer> task = sut.GetCustomerAsync(testData.CustomerId);
            Task.WaitAll(task);
            if (task.IsFaulted)
            {
                throw task.Exception;
            }

            ICustomer result = task.Result;
            Assert.AreEqual(testData.CustomerName,result.CustomerName);
            Assert.AreEqual(testData.AddressLine1,result.AddressLine1);
            Assert.AreEqual(testData.AddressLine2,result.AddressLine2);
            Assert.AreEqual(testData.City,result.City);
            Assert.AreEqual(testData.State,result.State);
            Assert.AreEqual(testData.Zip,result.Zip);
            Assert.AreEqual(testData.Country,result.Country);
        }
    }
}