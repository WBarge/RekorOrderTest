using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Glue.Exceptions;
using Order.Glue.Extensions;
using Order.Service.Models.Requests;
using Order.Service.Models.Responses;

namespace Order.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageForClient), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessageForClient), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] NewOrderRequest request)
        {
            request.CustomerId.Required(nameof(request.CustomerId));
            request.ProductId.Required(nameof(request.ProductId));
            if (!request.Quantity.IsPositiveInt())
            {
                throw new RequestException("Quantity has to be a positive number");
            }

            return new OkResult();
        }
    }
}