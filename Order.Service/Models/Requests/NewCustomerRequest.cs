// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-19-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-19-2022
// ***********************************************************************
// <copyright file="NewCustomerRequest.cs" company="Order.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Order.Glue.Interfaces.DTOs;

namespace Order.Service.Models.Requests
{
    /// <summary>
    /// Class NewCustomerRequest.
    /// Implements the <see cref="Order.Glue.Interfaces.DTOs.ICustomer" />
    /// </summary>
    /// <seealso cref="Order.Glue.Interfaces.DTOs.ICustomer" />
    public class NewCustomerRequest:ICustomer
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [JsonIgnore]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [JsonProperty(PropertyName = "addressLine1")]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        [JsonProperty(PropertyName = "addressLine2")]
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

    }
}