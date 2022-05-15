using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;

namespace Order.Data.Ef.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepo(OrderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext) + " is manditory");
        }


        public async Task SaveNewOrderAsync(IProduct product, ICustomer customer, DateTime orderDate, int quantityOrdered, decimal orderTotal,CancellationToken token = default)
        {
            Entities.Order order = new Entities.Order()
            {
                Product = DataTransformer.Transform(product),
                Customer = DataTransformer.Transform(customer),
                OrderDate = orderDate,
                Quantity = quantityOrdered,
                PricePaid = orderTotal
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}