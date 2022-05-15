using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Glue.Extensions;

namespace Order.Data.Ef.DBSchemaHelp
{
    public static class DbSchemaExtension
    {
        public static void HandleDbSchema(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            OrderDbContext dbContext = provider.GetRequiredService<OrderDbContext>();
            dbContext.Required(nameof(dbContext));
            dbContext.Database.Migrate();

        }

        public static void HandleDbSchema(this IApplicationBuilder app, IConfiguration config)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                OrderDbContext context = serviceScope.ServiceProvider.GetRequiredService<OrderDbContext>();
                // auto migration
                context.Database.Migrate();
                // Seed the database.
            }
        }
    }
}