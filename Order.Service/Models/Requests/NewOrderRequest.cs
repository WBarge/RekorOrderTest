// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-12-2022
// ***********************************************************************
// <copyright file="NewOrderRequest.cs" company="Order.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;

namespace Order.Service.Models.Requests
{
    /// <summary>
    /// Class NewOrderRequest.
    /// </summary>
    public class NewOrderRequest
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        [JsonProperty(PropertyName = "productId")]
        public Guid ProductId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [JsonProperty(PropertyName = "customerId")]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}