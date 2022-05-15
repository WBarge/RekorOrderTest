// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-13-2022
// ***********************************************************************
// <copyright file="DataTransformer.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Order.Data.Ef.Entities;
using Order.Glue.Interfaces.DTOs;

namespace Order.Data.Ef.Repos
{

    //todo look into a tools such as automapper

    /// <summary>
    /// Class DataTransformer.
    /// </summary>
    public class DataTransformer
    {
        /// <summary>
        /// Transforms the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Product.</returns>
        public static Product Transform(IProduct product)
        {
            if (product is Product)
            {
                return (Product)product;
            }
            else
            {
                return new Product()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    PricePerItem = product.PricePerItem,
                    AverageCustomerRating = product.AverageCustomerRating
                };
            }
        }

        /// <summary>
        /// Transforms the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>Customer.</returns>
        public static Customer Transform(ICustomer customer)
        {
            if (customer is Customer)
            {
                return (Customer)customer;
            }
            else
            {
                return new Customer()
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    AddressLine1 = customer.AddressLine1,
                    AddressLine2 = customer.AddressLine2,
                    City = customer.City,
                    State = customer.State,
                    Zip = customer.Zip,
                    Country = customer.Country
                };
            }
        }
    }
}