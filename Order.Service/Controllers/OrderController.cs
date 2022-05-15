// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-12-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-13-2022
// ***********************************************************************
// <copyright file="OrderController.cs" company="Order.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Glue.Exceptions;
using Order.Glue.Extensions;
using Order.Glue.Interfaces.Business;
using Order.Glue.Interfaces.DTOs;
using Order.Service.Models.Requests;
using Order.Service.Models.Responses;

namespace Order.Service.Controllers
{
    /// <summary>
    /// Class OrderController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        /// <summary>
        /// The order service
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="orderService">The order service.</param>
        /// <exception cref="ArgumentNullException">orderService</exception>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService) + " is manditory");
        }

        /// <summary>
        /// Creates a new order in the system
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IActionResult.</returns>
        /// <exception cref="RequestException">Quantity has to be a positive number</exception>
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

            await _orderService.ProcessNewOrderAsync(request.ProductId, request.CustomerId, request.Quantity);

            return new OkResult();
        }

        //todo - get updated requirements and refactor if needed - is an order that has shipped still an order or is it an invoice
        /// <summary>
        /// Gets all the pending orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IPendingOrder>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageForClient),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessageForClient),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<IPendingOrder> results = await _orderService.GetPendingOrdersAsync();
            return new OkObjectResult(results);
        }

    }
}