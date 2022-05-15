using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order.Data.Ef;
using Order.Data.Ef.DBSchemaHelp;

namespace Order.Tests.UnitTests.Data
{
    public static class DataContextCreator
    {
        public static OrderDbContext GetContext()
        {
            IServiceCollection services = CreateAndConfigureServiceCollection();
            ServiceProvider provider =services.BuildServiceProvider();
            OrderDbContext result = provider.GetRequiredService<OrderDbContext>();
            return result;
        }

        private static IServiceCollection CreateAndConfigureServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();
            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            string connectionString = connectionStringBuilder.ToString();
            SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            services.AddDbContext<OrderDbContext>(options => options.UseSqlite(connection));
            services.HandleDbSchema();
            return services;
        }
    }
}