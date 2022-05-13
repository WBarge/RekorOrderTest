using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Order.Service.Models.Responses;

namespace Order.Service.Middleware
{
    /// <summary>
    /// Class UiExceptionHandler.
    /// This class is responsible for creating a consistent result message to the client in the case of an error (aka a throw)
    /// </summary>
    public class UiExceptionHandler
    {
        /// <summary>
        /// The next piece in the pipeline
        /// </summary>
        readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="UiExceptionHandler" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public UiExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// called by the system as part of the request pipe-line
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
          
            catch (System.Exception x)
            {
                if (!context.Response.HasStarted)
                {
                    int statusCodeToSentToClient = x.GetType().Name switch
                    {
                        //TODO update with exception types used in the application aka map exceptions to web status codes
                        "ArgumentNullException" => (int) System.Net.HttpStatusCode.InternalServerError,
                        _ => (int) System.Net.HttpStatusCode.BadRequest
                    };

                    context.Response.StatusCode = statusCodeToSentToClient;
                    await BuildResponseBodyAsync(context, x);
                }
            }
        }

        /// <summary>
        /// build response body as an asynchronous operation.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="x">The x.</param>
        /// <returns>Task.</returns>
        public async Task BuildResponseBodyAsync(HttpContext context, System.Exception x)
        {
            ErrorMessageForClient errorStruct = new ErrorMessageForClient(x);
            string stringToSendToClient = JsonConvert.SerializeObject(errorStruct);

            await using StreamWriter sw = new StreamWriter(context.Response.Body);
            await sw.WriteAsync(stringToSendToClient);
        }
    }
}