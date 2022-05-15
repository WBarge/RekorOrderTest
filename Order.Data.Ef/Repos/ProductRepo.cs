using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Data.Ef.Entities;
using Order.Glue.Interfaces.Data;
using Order.Glue.Interfaces.DTOs;

namespace Order.Data.Ef.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly OrderDbContext _dbContext;

        public ProductRepo(OrderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext) + " is manditory");
        }

        public async Task<IProduct> GetProductAsync(Guid productId,CancellationToken token = default)
        {
            return await _dbContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync(token);
        }
    }
}