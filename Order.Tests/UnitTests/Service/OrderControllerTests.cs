using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Order.Glue.Exceptions;
using Order.Glue.Interfaces.Business;
using Order.Service.Controllers;
using Order.Service.Models.Requests;

namespace Order.Tests.UnitTests.Service
{
    [TestFixture]
    public class OrderControllerTests
    {
        private Mock<IOrderService> _orderServiceMock;

        [SetUp]
        public void TestsInit()
        {
            _orderServiceMock = new Mock<IOrderService>();
        }

        [Test]
        public void EnsureOrderServiceIsRequired()
        {
            Assert.Throws<ArgumentNullException>(() => new OrderController(null));
        }

        [Test]
        public void CanCreateInstanceOfController()
        {
            OrderController sut = new OrderController(_orderServiceMock.Object);
            Assert.IsNotNull(sut);
        }

        [Test]
        public void EmptyCustomerIdThrows()
        {
            OrderController sut = new OrderController(_orderServiceMock.Object);
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
            OrderController sut = new OrderController(_orderServiceMock.Object);
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
            OrderController sut = new OrderController(_orderServiceMock.Object);
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
            OrderController sut = new OrderController(_orderServiceMock.Object);
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

        [Test]
        public void PostDoesProcessTheOrder()
        {
            _orderServiceMock
                .Setup(m => m.ProcessNewOrderAsync(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), default))
                .Returns(Task.CompletedTask);

            NewOrderRequest testData = new NewOrderRequest()
            {
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 2
            };

            OrderController sut = new OrderController(_orderServiceMock.Object);
            Task<IActionResult> task = sut.PostAsync(testData);
            Task.WaitAll(task);
            if (task.IsFaulted)
            {
                throw task.Exception;
            }
            _orderServiceMock.Verify();

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