// ***********************************************************************
// Assembly         : Order.Service
// Author           : Bill Barge
// Created          : 05-15-2022
//
// Last Modified By : Bill Barge
// Last Modified On : 05-15-2022
// ***********************************************************************
// <copyright file="Product.cs" company="Order.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Class ProductController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <exception cref="ArgumentNullException">productService</exception>
        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService) + " is manditory");
        }


        /// <summary>
        /// Get all products ordered the average customer rating
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IProduct>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageForClient),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessageForClient),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<IProduct> results = await _productService.GetAllProductsByAverageCustomerRatingAsync();
            List<IProduct> returnValue = results.Select(product => new Product(product)).Cast<IProduct>().ToList();
            return new OkObjectResult(returnValue);
        }

        /// <summary>
        /// adds a product to the system
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IActionResult.</returns>
        /// <exception cref="RequestException">AverageCustomerRating has to be a positive number</exception>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageForClient), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessageForClient), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] NewProductRequest request)
        {
            request.Required(nameof(request));
            request.ProductId.RequiredEmpty(nameof(request.ProductId));
            request.ProductName.Required(nameof(request.ProductName));
            request.PricePerItem.Required(nameof(request.PricePerItem));
            if (!request.AverageCustomerRating.IsPositiveInt())
            {
                throw new RequestException("AverageCustomerRating has to be a positive number");
            }

            await _productService.AddProductAsync(request);

            return new OkResult();
        }

    }
}