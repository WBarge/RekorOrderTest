﻿using Microsoft.AspNetCore.Builder;

namespace Order.Service.Middleware
{
    /// <summary>
    /// Class UiExceptionHandlerExtensions.
    /// This class is responsible for registering an exception handler in the pipeline
    /// </summary>
    public static class UiExceptionHandlerExtensions
    {
        /// <summary>
        /// Uses the UI exception handler.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseUIExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UiExceptionHandler>();
        }
    }
}