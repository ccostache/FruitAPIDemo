using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FruitApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        /// <summary>
        /// Gets the next middleware in the pipeline
        /// </summary>
        private RequestDelegate Next;

        /// <summary>
        /// NLog provider logger
        /// </summary>
        private Logger NLogger { get; } = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The reason phase to return in our response when catching an exception
        /// </summary>
        const string REASON_PHASE = "Unexpected error occured";

        /// <summary>
        /// Initialise a new instance of the global exception middleware class
        /// </summary>
        /// <param name="next"></param>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.Next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Invoke the next middleware in the configured pipeline
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }
            }
            catch (HttpException httpException)
            {
                if (httpException.InnerException != null)
                {
                    logger.LogWarning(httpException.InnerException, "Inner HTTP Exception");
                }

                context.Response.StatusCode = httpException.StatusCode;
                var responseFeature = context.Features.Get<IHttpResponseFeature>();
                responseFeature.ReasonPhrase = REASON_PHASE;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    logger.LogWarning(ex.InnerException, $"HTTP exception {ex.InnerException.Message}");
                }

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var responseFeature = context.Features.Get<IHttpResponseFeature>();
                responseFeature.ReasonPhrase = REASON_PHASE;
            }
        }
    }
}
