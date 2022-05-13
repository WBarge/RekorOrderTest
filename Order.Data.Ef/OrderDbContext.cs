// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-12-2022
// ***********************************************************************
// <copyright file="OrderDbContext.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>The basic DBContext for the system</summary>
// ***********************************************************************
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Order.Data.Ef.Entities;

namespace Order.Data.Ef
{
    /// <summary>
    /// Class OrderDbContext.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class OrderDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        public DbSet<Entities.Order> Orders { get; set; }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options){}

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //find all classes that implement IEntityTypeConfiguration and execute their Configure method
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
}
