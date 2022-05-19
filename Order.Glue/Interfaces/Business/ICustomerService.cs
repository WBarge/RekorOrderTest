using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Order.Glue.Interfaces.DTOs;

namespace Order.Glue.Interfaces.Business
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;IEnumerable&lt;ICustomer&gt;&gt;.</returns>
        Task<IEnumerable<ICustomer>> GetAllCustomersAsync(CancellationToken token = default);

        /// <summary>
        /// Adds the new customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task.</returns>
        Task AddNewCustomerAsync(ICustomer customer, CancellationToken token = default);
    }
}