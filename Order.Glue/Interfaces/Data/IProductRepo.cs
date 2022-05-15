using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.DTOs;

namespace Order.Glue.Interfaces.Data
{
    public interface IProductRepo
    {
        Task<IProduct> GetProductAsync(Guid productId,CancellationToken token = default);
    }
}