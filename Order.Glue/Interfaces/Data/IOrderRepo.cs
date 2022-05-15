// ***********************************************************************
// Assembly         : Order.Glue
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="IOrderRepo.cs" company="Order.Glue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Order.Glue.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Glue.Interfaces.Data
{
    /// <summary>
    /// Interface IOrderRepo
    /// </summary>
    public interface IOrderRepo
    {
        /// <summary>
        /// Saves the new order asynchronous.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="orderDate">The order date.</param>
        /// <param name="quantityOrdered">The quantity ordered.</param>
        /// <param name="orderTotal">The order total.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task SaveNewOrderAsync(IProduct product, ICustomer customer, DateTime orderDate, int quantityOrdered, decimal orderTotal,CancellationToken token = default);
        /// <summary>
        /// Gets the pending orders asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IPendingOrder&gt;&gt;.</returns>
        Task<IEnumerable<IPendingOrder>> GetPendingOrdersAsync(CancellationToken token = default);
    }
}