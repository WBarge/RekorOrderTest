// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="RootComposition.cs" company="Order.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Order.Data.Ef;
using Order.Data.Ef.Repos;
using Order.Glue.Interfaces.Business;
using Order.Glue.Interfaces.Data;
using Order.Business;

namespace Order.Service.Utilities
{
    /// <summary>
    /// Class RootComposition.
    /// </summary>
    public static class RootComposition
    {
        /// <summary>
        /// Configures the di.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureDi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<OrderDbContext>(builder =>
            {
                builder.UseSqlServer(configuration["ConnectionString"]);
            });

            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<ICustomerRepo,CustomerRepo>();
            services.AddTransient<IOrderRepo, OrderRepo>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}