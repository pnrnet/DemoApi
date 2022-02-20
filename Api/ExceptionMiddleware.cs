// <copyright file="ExceptionMiddleware.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>Student Controllerr Class.</summary>


namespace Api
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Purpose of this class is Exception Middleware.
    /// </summary>
    public class ExceptionMiddleware
    {
        /// <summary>
        /// The next request.
        /// </summary>
        private readonly RequestDelegate nextRequest;

        /// <summary>
        /// Logger Method
        /// </summary>
        private readonly ILogger logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            nextRequest = next;
            logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            
            try
            {
                await nextRequest(httpContext);
             
            }
            catch (ApplicationException ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                HandleException(httpContext, ex);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                HandleException(httpContext, ex);
            }
            finally
            {
               
                //logger.LogInformation(loggingInfo.ToString()); Logs the Information here
            }
        }

        private void HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            List<System.Exception> exceptionList = new List<System.Exception>
                {
                    exception,
                };
            //logger.LogError() Handles Error Herer 
            return;
        }
    }
}
