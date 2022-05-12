using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Ef.Entities
{
    public class Product
    {
        public Guid ProductId { get;set;}
        public string ProductName { get;set;}
        public decimal PricePerItem { get;set;}
        public int AverageCustomerRating { get;set;}
    }
}
