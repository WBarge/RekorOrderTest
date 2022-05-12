using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Ef.Entities
{
    public class Customer
    {
        public Guid CustomerId { get;set;}
        public string CustomerName { get;set;}
        public string AddressLine1 { get;set;}
        public string AddressLine2 { get;set;}
        public string City { get;set;}
        public string State { get;set;}
        public string Zip { get;set;}
        public string Country { get; set;}
    }
}
