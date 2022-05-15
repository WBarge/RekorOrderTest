using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;

namespace Order.Data.Ef.Repos
{
    public class CustomerRepo : ICustomerRepo
    {

        private readonly OrderDbContext _dbContext;

        public CustomerRepo(OrderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext) + " is manditory");
        }

        public async Task<ICustomer> GetCustomerAsync(Guid customerId, CancellationToken token=default)
        {
            return await _dbContext.Customers.Where(c => c.CustomerId == customerId).FirstOrDefaultAsync(token);
        }
    }
}