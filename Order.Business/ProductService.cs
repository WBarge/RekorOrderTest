// ***********************************************************************
// Assembly         : Order.Business
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="ProductService.cs" company="Order.Business">
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
    /// Class ProductService.
    /// Implements the <see cref="IProductService" />
    /// </summary>
    /// <seealso cref="IProductService" />
    public class ProductService : IProductService
    {
        /// <summary>
        /// The product repo
        /// </summary>
        private readonly IProductRepo _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepo">The product repo.</param>
        /// <exception cref="ArgumentNullException">productRepo</exception>
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo) + " is manditory");
        }

        /// <summary>
        /// Gets all products ordered by the average customer rating asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IProduct&gt;&gt;.</returns>
        public Task<IEnumerable<IProduct>> GetAllProductsByAverageCustomerRatingAsync(CancellationToken token = default)
        {
            return _productRepo.GetAllProductsByAverageCustomerRatingAsync(token);
        }
    }
}