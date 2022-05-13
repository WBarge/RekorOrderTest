using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Order.Data.Ef;

namespace EFC_Tools
{
    public class DbContextFactory: IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<OrderDbContext>();

            var conStr = conf["ConnectionString"];

            dbContextBuilder.UseSqlServer(conStr);

            return new OrderDbContext(dbContextBuilder.Options);
        }
    }
}
