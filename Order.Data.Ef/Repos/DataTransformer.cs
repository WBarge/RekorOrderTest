using Order.Data.Ef.Entities;
using Order.Glue.Interfaces.DTOs;

namespace Order.Data.Ef.Repos
{

    //todo look into a tools such as automapper

    public class DataTransformer
    {
        public static Product Transform(IProduct product)
        {
            if (product is Product)
            {
                return (Product)product;
            }
            else
            {
                return new Product()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    PricePerItem = product.PricePerItem,
                    AverageCustomerRating = product.AverageCustomerRating
                };
            }
        }

        public static Customer Transform(ICustomer customer)
        {
            if (customer is Customer)
            {
                return (Customer)customer;
            }
            else
            {
                return new Customer()
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    AddressLine1 = customer.AddressLine1,
                    AddressLine2 = customer.AddressLine2,
                    City = customer.City,
                    State = customer.State,
                    Zip = customer.Zip,
                    Country = customer.Country
                };
            }
        }
    }
}