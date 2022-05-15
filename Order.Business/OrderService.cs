using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.Business;
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;

namespace Order.Business
{
    public class OrderService : IOrderService
    {

        private readonly IProductRepo _productRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly IOrderRepo _orderRepo;

        public OrderService(IProductRepo productRepo, ICustomerRepo customerRepo, IOrderRepo orderRepo)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo) + " is manditory");
            _customerRepo = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo) + " is manditory");
            _orderRepo = orderRepo ?? throw new ArgumentNullException(nameof(orderRepo) + " is manditory");
        }


        public async Task ProcessNewOrderAsync(Guid productId, Guid customerId, int quantityOrdered,CancellationToken token = default)
        {
            Task<IProduct> productTask = _productRepo.GetProductAsync(productId,token);
            Task<ICustomer> customerTask = _customerRepo.GetCustomerAsync(customerId, token);

            Task.WaitAll(new Task[] { productTask, customerTask }, token);

            if (productTask.IsFaulted)
            {
                // ReSharper disable once PossibleNullReferenceException
                throw productTask.Exception;
            }

            if (customerTask.IsFaulted)
            {
                // ReSharper disable once PossibleNullReferenceException
                throw customerTask.Exception;
            }

            IProduct product = productTask.Result;
            ICustomer customer = customerTask.Result;
            decimal orderTotal = product.PricePerItem * quantityOrdered;

            await _orderRepo.SaveNewOrderAsync(product, customer, DateTime.UtcNow, quantityOrdered, orderTotal,token);
        }
    }
}