// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="OrderRepo.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Data.Ef.DTOs;
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;

namespace Order.Data.Ef.Repos
{
    /// <summary>
    /// Class OrderRepo.
    /// Implements the <see cref="Order.Glue.Interfaces.Data.IOrderRepo" />
    /// </summary>
    /// <seealso cref="Order.Glue.Interfaces.Data.IOrderRepo" />
    public class OrderRepo : IOrderRepo
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly OrderDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepo"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="ArgumentNullException">dbContext</exception>
        public OrderRepo(OrderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext) + " is manditory");
        }

        /// <summary>
        /// save new order as an asynchronous operation.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="orderDate">The order date.</param>
        /// <param name="quantityOrdered">The quantity ordered.</param>
        /// <param name="orderTotal">The order total.</param>
        /// <param name="token">The token.</param>
        public async Task SaveNewOrderAsync(IProduct product, ICustomer customer, DateTime orderDate, int quantityOrdered, decimal orderTotal,CancellationToken token = default)
        {
            Entities.Order order = new Entities.Order()
            {
                Product = DataTransformer.Transform(product),
                Customer = DataTransformer.Transform(customer),
                OrderDate = orderDate,
                Quantity = quantityOrdered,
                PricePaid = orderTotal
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// get pending orders as an asynchronous operation.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>IEnumerable&lt;IPendingOrder&gt;.</returns>
        public async Task<IEnumerable<IPendingOrder>> GetPendingOrdersAsync(CancellationToken token = default)
        {
            List<PendingOrder> pendingOrders = await  _dbContext.Orders
                .Include(o=>o.Customer)
                .Where(o=>o.ShippedDate == DateTime.MinValue)
                .Select( r => new PendingOrder()
                {
                    CustomerId = r.Customer.CustomerId,
                    CustomerName = r.Customer.CustomerName,
                    OrderId = r.OrderId,
                    OrderDate = r.OrderDate,
                    Quantity = r.Quantity,
                    PricePaid = r.PricePaid
                })
                .ToListAsync();
            return pendingOrders;
        }
    }
}