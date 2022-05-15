// ***********************************************************************
// Assembly         : Order.Data.Ef
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="DbSchemaExtension.cs" company="Order.Data.Ef">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order.Glue.Extensions;

namespace Order.Data.Ef.DBSchemaHelp
{
    /// <summary>
    /// Class DbSchemaExtension.
    /// </summary>
    public static class DbSchemaExtension
    {
        /// <summary>
        /// Handles the database schema.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void HandleDbSchema(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            OrderDbContext dbContext = provider.GetRequiredService<OrderDbContext>();
            dbContext.Required(nameof(dbContext));
            dbContext.Database.Migrate();

        }
    }
}