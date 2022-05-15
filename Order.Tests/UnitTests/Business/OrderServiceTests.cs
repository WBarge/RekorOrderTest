using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Order.Business;
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;

namespace Order.Tests.UnitTests.Business
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IProductRepo> _productRepoMock;
        private Mock<ICustomerRepo> _customerRepoMock;
        private Mock<IOrderRepo> _orderRepoMock;


        [SetUp]
        public void TestsInit()
        {
            _productRepoMock = new Mock<IProductRepo>();
            _customerRepoMock = new Mock<ICustomerRepo>();
            _orderRepoMock = new Mock<IOrderRepo>();
        }

        [Test]
        public void EnsureReposAreRequired()
        {
            Assert.Throws<ArgumentNullException>(() => new OrderService(null,null,null));
        }

        [Test]
        public void EnsureProductRepoIsRequired()
        {
            Assert.Throws<ArgumentNullException>(() => new OrderService(null,_customerRepoMock.Object,_orderRepoMock.Object));
        }

        [Test]
        public void EnsureCustomerRepoIsRequired()
        {
            Assert.Throws<ArgumentNullException>(() => new OrderService(_productRepoMock.Object,null,_orderRepoMock.Object));
        }

        [Test]
        public void EnsureOrderRepoIsRequired()
        {
            Assert.Throws<ArgumentNullException>(() => new OrderService(_productRepoMock.Object,_customerRepoMock.Object,null));
        }


        [Test]
        public void CanCreateInstanceOfService()
        {
            OrderService sut = new OrderService(_productRepoMock.Object,_customerRepoMock.Object,_orderRepoMock.Object);
            Assert.IsNotNull(sut);
        }


        [Test]
        public void CanProcessANewOrder()
        {
            Mock<IProduct> mockProduct = new Mock<IProduct>();
            Mock<ICustomer> mockCustomer = new Mock<ICustomer>();

            _productRepoMock.Setup(m => m.GetProductAsync(It.IsAny<Guid>(), default))
                .Returns(Task.FromResult(mockProduct.Object));

            _customerRepoMock.Setup(m => m.GetCustomerAsync(It.IsAny<Guid>(), default))
                .Returns(Task.FromResult(mockCustomer.Object));

            _orderRepoMock.Setup(m => m.SaveNewOrderAsync(mockProduct.Object, mockCustomer.Object, It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<decimal>(), default));

            OrderService sut = new OrderService(_productRepoMock.Object,_customerRepoMock.Object,_orderRepoMock.Object);
            Task task = sut.ProcessNewOrderAsync(Guid.NewGuid(), Guid.NewGuid(), 2);
            Task.WaitAll(task);
            if (task.IsFaulted)
            {
                throw task.Exception;
            }

            _customerRepoMock.Verify();
            _productRepoMock.Verify();
            _orderRepoMock.Verify();

        }


    }
}