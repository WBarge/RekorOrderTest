// ***********************************************************************
// Assembly         : Order.Business
// Author           : Bill Barge
// Created          : 05-19-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-19-2022
// ***********************************************************************
// <copyright file="CustomerService.cs" company="Order.Business">
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
    /// Class CustomerService.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// The customer repo
        /// </summary>
        private readonly ICustomerRepo _customerRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="customerRepo">The customer repo.</param>
        /// <exception cref="ArgumentNullException">customerRepo</exception>
        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo) + " is manditory");
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;ICustomer&gt;&gt;.</returns>
        public Task<IEnumerable<ICustomer>> GetAllCustomersAsync(CancellationToken token = default)
        {
            return _customerRepo.GetAllCustomersByNameAsync(token);
        }

        /// <summary>
        /// Adds the new customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        public Task AddNewCustomerAsync(ICustomer customer, CancellationToken token = default)
        {
            return _customerRepo.InsertAsync(customer, token);
        }
    }
}