// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-19-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-19-2022
// ***********************************************************************
// <copyright file="Customer.cs" company="Order.Service">
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
    /// Class Customer.
    /// Implements the <see cref="Order.Glue.Interfaces.DTOs.ICustomer" />
    /// </summary>
    /// <seealso cref="Order.Glue.Interfaces.DTOs.ICustomer" />
    public class CustomerResponse :ICustomer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerResponse"/> class.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public CustomerResponse(ICustomer customer)
        {
            this.CustomerId = customer.CustomerId;
            this.CustomerName = customer.CustomerName;
            this.AddressLine1 = customer.AddressLine1;
            this.AddressLine2 = customer.AddressLine2;
            this.City = customer.City;
            this.State = customer.State;
            this.Zip = customer.Zip;
            this.Country = customer.Country;
        }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [JsonProperty(PropertyName = "customerId")]
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