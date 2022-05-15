using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Glue.Interfaces.Business
{
    public interface IOrderService
    {
        Task ProcessNewOrderAsync(Guid productId, Guid customerId, int quantityOrdered,CancellationToken token = default);
    }
}