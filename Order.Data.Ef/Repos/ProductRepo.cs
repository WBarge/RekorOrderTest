// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="ProductRepo.cs" company="Order.Data.Ef">
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
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;
using Product = Order.Data.Ef.Entities.Product;

namespace Order.Data.Ef.Repos
{
    /// <summary>
    /// Class ProductRepo.
    /// Implements the <see cref="Order.Glue.Interfaces.Data.IProductRepo" />
    /// </summary>
    /// <seealso cref="Order.Glue.Interfaces.Data.IProductRepo" />
    public class ProductRepo : IProductRepo
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly OrderDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepo"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="ArgumentNullException">dbContext</exception>
        public ProductRepo(OrderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext) + " is manditory");
        }

        /// <summary>
        /// get product as an asynchronous operation.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>IProduct.</returns>
        public async Task<IProduct> GetProductAsync(Guid productId,CancellationToken token = default)
        {
            return await _dbContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync(token);
        }

        /// <summary>
        /// get all products by average customer rating as an asynchronous operation.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>IEnumerable&lt;IProduct&gt;.</returns>
        public async Task<IEnumerable<IProduct>> GetAllProductsByAverageCustomerRatingAsync(CancellationToken token = default)
        {
            return  await _dbContext.Products.OrderByDescending(p => p.AverageCustomerRating).ToListAsync(token);
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="rec">The record.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task InsertAsync(IProduct rec,CancellationToken cancellationToken =default)
        {
            await Task.Run(async () =>
            {
                Product recToInsert;
                if (rec is Product services)
                {
                    recToInsert = services;
                }
                else
                {
                    recToInsert = MSSqlDataTransformer.ConvertToProduct(rec);
                }

                _dbContext.Products.Add(recToInsert);
                await _dbContext.SaveChangesAsync(cancellationToken);

            }, cancellationToken).ConfigureAwait(false);
        }
    }
}