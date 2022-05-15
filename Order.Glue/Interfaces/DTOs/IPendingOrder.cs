// ***********************************************************************
// Assembly         : Order.Glue
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="IPendingOrder.cs" company="Order.Glue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Order.Glue.Interfaces.DTOs
{
    /// <summary>
    /// Interface IPendingOrder
    /// </summary>
    public interface IPendingOrder
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        Guid OrderId { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price paid.
        /// </summary>
        /// <value>The price paid.</value>
        decimal PricePaid { get; set; }
    }
}