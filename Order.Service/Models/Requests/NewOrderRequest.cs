using System;
using Newtonsoft.Json;

namespace Order.Service.Models.Requests
{
    public class NewOrderRequest
    {
        [JsonProperty(PropertyName = "productId")]
        public Guid ProductId { get; set; }
        [JsonProperty(PropertyName = "customerId")]
        public Guid CustomerId { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}