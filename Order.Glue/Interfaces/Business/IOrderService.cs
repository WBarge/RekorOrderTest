// ***********************************************************************
// Assembly         : Order.Glue
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="IOrderService.cs" company="Order.Glue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.DTOs;

namespace Order.Glue.Interfaces.Business
{
    /// <summary>
    /// Interface IOrderService
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Processes the new order asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="quantityOrdered">The quantity ordered.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task ProcessNewOrderAsync(Guid productId, Guid customerId, int quantityOrdered,CancellationToken token = default);

        /// <summary>
        /// Gets the pending orders asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IPendingOrder&gt;&gt;.</returns>
        Task<IEnumerable<IPendingOrder>> GetPendingOrdersAsync(CancellationToken token = default);
    }
}