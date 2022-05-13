// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-12-2022
// ***********************************************************************
// <copyright file="Product.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Order.Data.Ef.Entities
{
    /// <summary>
    /// Class Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get;set;}
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName { get;set;}
        /// <summary>
        /// Gets or sets the price per item.
        /// </summary>
        /// <value>The price per item.</value>
        public decimal PricePerItem { get;set;}
        /// <summary>
        /// Gets or sets the average customer rating.
        /// </summary>
        /// <value>The average customer rating.</value>
        public int AverageCustomerRating { get;set;}

        public ICollection<Order> Orders { get; set; }
    }
}
