// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-19-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-19-2022
// ***********************************************************************
// <copyright file="CustomerController.cs" company="Order.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Order.Glue.Extensions;
using Order.Glue.Interfaces.Business;
using Order.Glue.Interfaces.DTOs;
using Order.Service.Models.Requests;
using Order.Service.Models.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order.Service.Controllers
{
    /// <summary>
    /// Class CustomerController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        /// <summary>
        /// The customer service
        /// </summary>
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        /// <exception cref="ArgumentNullException">customerService</exception>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService) + " is manditory");
        }


        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ICustomer>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageForClient),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessageForClient),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<ICustomer> results = await _customerService.GetAllCustomersAsync();
            List<ICustomer> returnValue =
                results.Select(customer => new CustomerResponse(customer)).Cast<ICustomer>().ToList();
            return new OkObjectResult(returnValue);
        }

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageForClient), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessageForClient), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NewCustomerRequest request)
        {
            request.Required(nameof(request));
            request.CustomerId.RequiredEmpty(nameof(request.CustomerId));
            request.CustomerName.Required(nameof(request.CustomerName));
            
            await _customerService.AddNewCustomerAsync(request);

            return new OkResult();

        }
    }
}
