// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-13-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="ProductRepo.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Order.Glue.Interfaces.DTOs;
using System;
using Order.Data.Ef.Entities;

namespace Order.Data.Ef
{
    internal class MSSqlDataTransformer
    {
        internal static Product ConvertToProduct(IProduct rec)
        {
            return new Product
            {
                ProductId = rec.ProductId,
                ProductName = rec.ProductName,
                PricePerItem = rec.PricePerItem,
                AverageCustomerRating = rec.AverageCustomerRating
            };
        }

        public static Customer ConvertToCustomer(ICustomer rec)
        {
            return new Customer
            {
                CustomerId = rec.CustomerId,
                CustomerName = rec.CustomerName,
                AddressLine1 = rec.AddressLine1,
                AddressLine2 = rec.AddressLine2,
                City = rec.City,
                State = rec.State,
                Zip = rec.Zip,
                Country = rec.Country
            };
        }
    }
}