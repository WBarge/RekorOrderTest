// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="DBSeeder.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.EntityFrameworkCore;
using Order.Data.Ef.Entities;

namespace Order.Data.Ef.Seeding
{
    /// <summary>
    /// Class DBSeeder.
    /// </summary>
    public static class DbSeeder
    {
        /// <summary>
        /// Populates the db with default data.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid c1 = Guid.NewGuid();
            Guid c2 = Guid.NewGuid();

            Guid p1 = Guid.NewGuid();
            Guid p2 = Guid.NewGuid();
            Guid p3 = Guid.NewGuid();

            decimal price1 = (decimal)9.99;



            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer {  CustomerId = c1, 
                                    CustomerName = "Eddie" , 
                                    AddressLine1 ="666 Mockingbird Ln",
                                    City = "Mockingbird Heights",
                                    State = "Ca",
                                    Zip = "66666",
                                    Country = "USA"
                    },
                    new Customer {  CustomerId = c2, 
                                    CustomerName = "Hurman" , 
                                    AddressLine1 ="666 Mockingbird Ln",
                                    City = "Mockingbird Heights",
                                    State = "Ca",
                                    Zip = "66666",
                                    Country = "USA"
                    }
                );
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        ProductId = p1,
                        ProductName = "Widget1",
                        PricePerItem = price1,
                        AverageCustomerRating = 7
                    },
                    new Product
                    {
                        ProductId = p2,
                        ProductName = "Widget2",
                        PricePerItem = price1,
                        AverageCustomerRating = 10
                    },
                    new Product
                    {
                        ProductId = p3,
                        ProductName = "Widget3",
                        PricePerItem = price1,
                        AverageCustomerRating = 9
                    }
                );
        }
    }
}