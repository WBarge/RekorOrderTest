// ***********************************************************************
// Assembly         : Order.Glue
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-13-2022
// ***********************************************************************
// <copyright file="IProduct.cs" company="Order.Glue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Order.Glue.Interfaces.DTOs
{
    /// <summary>
    /// Interface IProduct
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the price per item.
        /// </summary>
        /// <value>The price per item.</value>
        decimal PricePerItem { get; set; }

        /// <summary>
        /// Gets or sets the average customer rating.
        /// </summary>
        /// <value>The average customer rating.</value>
        int AverageCustomerRating { get; set; }
    }
}