// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-13-2022
// ***********************************************************************
// <copyright file="CustomerRepo.cs" company="Order.Data.Ef">
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
using Customer = Order.Data.Ef.Entities.Customer;

namespace Order.Data.Ef.Repos
{
    /// <summary>
    /// Class CustomerRepo.
    /// Implements the <see cref="Order.Glue.Interfaces.Data.ICustomerRepo" />
    /// </summary>
    /// <seealso cref="Order.Glue.Interfaces.Data.ICustomerRepo" />
    public class CustomerRepo : ICustomerRepo
    {

        /// <summary>
        /// The database context
        /// </summary>
        private readonly OrderDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepo"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="ArgumentNullException">dbContext</exception>
        public CustomerRepo(OrderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext) + " is manditory");
        }

        /// <summary>
        /// get customer as an asynchronous operation.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>ICustomer.</returns>
        public async Task<ICustomer> GetCustomerAsync(Guid customerId, CancellationToken token=default)
        {
            return await _dbContext.Customers.Where(c => c.CustomerId == customerId).FirstOrDefaultAsync(token);
        }

        /// <summary>Gets the name of all customers by.</summary>
        /// <param name="token">The token.</param>
        /// <returns>IEnumerable&lt;ICustomer&gt;.</returns>
        public async Task<IEnumerable<ICustomer>> GetAllCustomersByNameAsync(CancellationToken token = default)
        {
            return await _dbContext.Customers.OrderByDescending(c => c.CustomerName).ToListAsync(token);
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="rec">The record.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task InsertAsync(ICustomer rec,CancellationToken cancellationToken =default)
        {
            await Task.Run(async () =>
            {
                Customer recToInsert;
                if (rec is Customer services)
                {
                    recToInsert = services;
                }
                else
                {
                    recToInsert = MSSqlDataTransformer.ConvertToCustomer(rec);
                }

                _dbContext.Customers.Add(recToInsert);
                await _dbContext.SaveChangesAsync(cancellationToken);

            }, cancellationToken).ConfigureAwait(false);
        }
    }
}