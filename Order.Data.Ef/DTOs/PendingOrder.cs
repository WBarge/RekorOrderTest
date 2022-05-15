// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="PendingOrder.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Order.Glue.Interfaces.DTOs;

namespace Order.Data.Ef.DTOs
{
    /// <summary>
    /// Class PendingOrder.
    /// </summary>
    public class PendingOrder : IPendingOrder
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public Guid OrderId { get; set; }
        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the price paid.
        /// </summary>
        /// <value>The price paid.</value>
        public decimal PricePaid { get; set; }
    }
}