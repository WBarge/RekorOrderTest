// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-17-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-17-2022
// ***********************************************************************
// <copyright file="Product.cs" company="Order.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Order.Glue.Interfaces.DTOs;

namespace Order.Service.Models.Responses
{
    /// <summary>
    /// Class Product.
    /// Implements the <see cref="Order.Glue.Interfaces.DTOs.IProduct" />
    /// </summary>
    /// <seealso cref="Order.Glue.Interfaces.DTOs.IProduct" />
    public class Product :IProduct
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        [JsonProperty(PropertyName = "productId")]
        public Guid ProductId { get; set; }
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }
        /// <summary>
        /// Gets or sets the price per item.
        /// </summary>
        /// <value>The price per item.</value>
        [JsonProperty(PropertyName = "pricePerItem")]
        public decimal PricePerItem { get; set; }
        /// <summary>
        /// Gets or sets the average customer rating.
        /// </summary>
        /// <value>The average customer rating.</value>
        [JsonProperty(PropertyName = "averageCustomerRating")]
        public int AverageCustomerRating { get; set; }

        public Product(IProduct p)
        {
            ProductId = p.ProductId;
            ProductName = p.ProductName;
            PricePerItem = p.PricePerItem;
            AverageCustomerRating = p.AverageCustomerRating;
        }
    }
}