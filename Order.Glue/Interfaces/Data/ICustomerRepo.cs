using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.DTOs;

namespace Order.Glue.Interfaces.Data
{
    public interface ICustomerRepo
    {
        Task<ICustomer> GetCustomerAsync(Guid customerId, CancellationToken token);
    }
}