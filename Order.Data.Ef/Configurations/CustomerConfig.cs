// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-12-2022
// ***********************************************************************
// <copyright file="CustomerConfig.cs" company="Order.Data.Ef">
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
    /// Class CustomerConfig.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Order.Data.Ef.Entities.Customer}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Order.Data.Ef.Entities.Customer}" />
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(k => k.CustomerId);
            builder.Property(p => p.CustomerId)
                .IsRequired(true)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.CustomerName)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.AddressLine1)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.AddressLine2)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.City)
                .HasColumnType("nvarchar(255)");
            builder.Property(x => x.State)
                .HasColumnType("nvarchar(40)");
            builder.Property(x => x.Zip)
                .HasColumnType("nvarchar(11)");
            builder.Property(x => x.Country)
                .HasColumnType("nvarchar(50)");

            //set many-1 relationship
            builder.HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer);
        }
    }
}
