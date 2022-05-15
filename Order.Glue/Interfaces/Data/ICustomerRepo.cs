﻿// ***********************************************************************
// Assembly         : Order.Glue
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-13-2022
// ***********************************************************************
// <copyright file="ICustomerRepo.cs" company="Order.Glue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.DTOs;

namespace Order.Glue.Interfaces.Data
{
    /// <summary>
    /// Interface ICustomerRepo
    /// </summary>
    public interface ICustomerRepo
    {
        /// <summary>
        /// Gets the customer asynchronous.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;ICustomer&gt;.</returns>
        Task<ICustomer> GetCustomerAsync(Guid customerId, CancellationToken token);
    }
}