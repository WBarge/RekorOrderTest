// ***********************************************************************
// Assembly         : Order.Business
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="OrderService.cs" company="Order.Business">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.Business;
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;

namespace Order.Business
{
    /// <summary>
    /// Class OrderService.
    /// Implements the <see cref="IOrderService" />
    /// </summary>
    /// <seealso cref="IOrderService" />
    public class OrderService : IOrderService
    {

        /// <summary>
        /// The product repo
        /// </summary>
        private readonly IProductRepo _productRepo;
        /// <summary>
        /// The customer repo
        /// </summary>
        private readonly ICustomerRepo _customerRepo;
        /// <summary>
        /// The order repo
        /// </summary>
        private readonly IOrderRepo _orderRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="productRepo">The product repo.</param>
        /// <param name="customerRepo">The customer repo.</param>
        /// <param name="orderRepo">The order repo.</param>
        /// <exception cref="ArgumentNullException">
        /// productRepo
        /// or
        /// customerRepo
        /// or
        /// orderRepo
        /// </exception>
        public OrderService(IProductRepo productRepo, ICustomerRepo customerRepo, IOrderRepo orderRepo)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo) + " is manditory");
            _customerRepo = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo) + " is manditory");
            _orderRepo = orderRepo ?? throw new ArgumentNullException(nameof(orderRepo) + " is manditory");
        }


        /// <summary>
        /// process aka creates a new order as an asynchronous operation.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="quantityOrdered">The quantity ordered.</param>
        /// <param name="token">The token.</param>
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

        /// <summary>
        /// Gets the pending orders asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IPendingOrder&gt;&gt;.</returns>
        public Task<IEnumerable<IPendingOrder>> GetPendingOrdersAsync(CancellationToken token = default)
        {
            return _orderRepo.GetPendingOrdersAsync(token);
        }
    }
}