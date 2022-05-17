// ***********************************************************************
// Assembly         : Order.Glue
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="IProductService.cs" company="Order.Glue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.DTOs;

namespace Order.Glue.Interfaces.Business
{
    /// <summary>
    /// Interface IProductService
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products by average customer rating asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IProduct&gt;&gt;.</returns>
        Task<IEnumerable<IProduct>> GetAllProductsByAverageCustomerRatingAsync(CancellationToken token = default);

        /// <summary>
        /// Adds the product asynchronous.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task AddProductAsync(IProduct product, CancellationToken token = default);

    }
}