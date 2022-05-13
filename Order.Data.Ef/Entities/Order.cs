// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-12-2022
// ***********************************************************************
// <copyright file="Order.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Order.Data.Ef.Entities
{
    /// <summary>
    /// Class Order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public Guid OrderId { get;set;}
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get;set;}
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get;set;}
        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        public DateTime OrderDate { get;set;}
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get;set;}
        /// <summary>
        /// Gets or sets the price paid.
        /// </summary>
        /// <value>The price paid.</value>
        public decimal PricePaid { get;set;}
        /// <summary>
        /// Gets or sets the shipped date.
        /// </summary>
        /// <value>The shipped date.</value>
        public DateTime ShippedDate { get;set;}
    }
}
