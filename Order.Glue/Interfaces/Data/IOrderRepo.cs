using Order.Glue.Interfaces.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Glue.Interfaces.Data
{
    public interface IOrderRepo
    {
        Task SaveNewOrderAsync(IProduct product, ICustomer customer, DateTime orderDate, int quantityOrdered, decimal orderTotal,CancellationToken token = default);
    }
}