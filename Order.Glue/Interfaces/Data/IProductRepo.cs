// ***********************************************************************
// Assembly         : Order.Glue
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="IProductRepo.cs" company="Order.Glue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.DTOs;

namespace Order.Glue.Interfaces.Data
{
    /// <summary>
    /// Interface IProductRepo
    /// </summary>
    public interface IProductRepo
    {
        /// <summary>
        /// Gets the product asynchronous.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IProduct&gt;.</returns>
        Task<IProduct> GetProductAsync(Guid productId,CancellationToken token = default);
        /// <summary>
        /// Gets all products by average customer rating asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IProduct&gt;&gt;.</returns>
        Task<IEnumerable<IProduct>> GetAllProductsByAverageCustomerRatingAsync(CancellationToken token = default);
    }
}