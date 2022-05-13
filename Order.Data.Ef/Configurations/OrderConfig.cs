// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-12-2022
// ***********************************************************************
// <copyright file="OrderConfig.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Order.Data.Ef.Entities;

namespace Order.Data.Ef.Configurations
{
    /// <summary>
    /// Class OrderConfig.
    /// Implements the <see cref="Order" />
    /// </summary>
    /// <seealso cref="Order" />
    internal class OrderConfig : IEntityTypeConfiguration<Entities.Order>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(k => k.OrderId);
            builder.Property(p => p.OrderId)
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            //set 1-many relationships
            builder.HasOne(order=>order.Product)
                .WithMany(product=> product.Orders);
            builder.HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders);
        }
    }
}
