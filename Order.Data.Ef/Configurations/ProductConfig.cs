// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-12-2022
// ***********************************************************************
// <copyright file="ProductConfig.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Data.Ef.Entities;

namespace Order.Data.Ef.Configurations
{
    /// <summary>
    /// Class ProductConfig.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Order.Data.Ef.Entities.Product}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Order.Data.Ef.Entities.Product}" />
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(k => k.ProductId);
            builder.Property(p => p.ProductId)
                .IsRequired(true)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.ProductName)
                .HasColumnType("nvarchar(255)");

            //set many-1 relationship
            builder.HasMany(product => product.Orders)
                .WithOne(order => order.Product);
        }
    }
}
