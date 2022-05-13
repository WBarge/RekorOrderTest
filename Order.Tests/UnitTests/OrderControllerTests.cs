using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Order.Glue.Exceptions;
using Order.Service.Controllers;
using Order.Service.Models.Requests;

namespace Order.Tests.UnitTests
{
    [TestFixture]
    public class OrderControllerTests
    {
        [SetUp]
        public void TestsInit()
        {
        }

        [Test]
        public void EmptyCustomerIdThrows()
        {
            OrderController sut = new OrderController();
            Assert.Throws<Exception>( () =>
            {
                Task<IActionResult> task = sut.PostAsync(BuildEmptyOrderRequest());
                while (!task.IsCompleted) { }

                if (task.IsFaulted && task.Exception.InnerException is RequiredObjectException)
                {
                    throw new Exception();
                }
            });
        }

        [Test]
        public void EmptyProductIdThrows()
        {
            OrderController sut = new OrderController();
            Assert.Throws<Exception>( () =>
            {
                NewOrderRequest  testData = BuildEmptyOrderRequest();
                testData.ProductId = Guid.Empty;
                Task<IActionResult> task = sut.PostAsync( testData);
                while (!task.IsCompleted) { }

                if (task.IsFaulted && task.Exception.InnerException is RequiredObjectException)
                {
                    throw new Exception();
                }
            });
        }

        [Test]
        public void ZeroQuantityThrows()
        {
            OrderController sut = new OrderController();
            Assert.Throws<Exception>( () =>
            {
                NewOrderRequest  testData = BuildOrderRequest();
                Task<IActionResult> task = sut.PostAsync( testData);
                while (!task.IsCompleted) { }

                if (task.IsFaulted && task.Exception.InnerException is RequestException)
                {
                    throw new Exception();
                }
            });
        }

        [Test]
        public void QuantityHasToPositiveThrows()
        {
            OrderController sut = new OrderController();
            Assert.Throws<Exception>( () =>
            {
                NewOrderRequest  testData = BuildOrderRequest();
                testData.Quantity = -1;
                Task<IActionResult> task = sut.PostAsync( testData);
                while (!task.IsCompleted) { }
                if (task.IsFaulted && task.Exception.InnerException is RequestException)
                {
                    throw new Exception();
                }
            });
        }

        private NewOrderRequest BuildEmptyOrderRequest()
        {
            return new NewOrderRequest
            {
                CustomerId = Guid.Empty
            };
        }
        private NewOrderRequest BuildOrderRequest()
        {
            return new NewOrderRequest
            {
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid()
            };
        }
    }
}