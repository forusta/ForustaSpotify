using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForustaSpotify.Api.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //TODO: Different exception types handling will be here
            catch (Exception ex)
            {
                _loggerFactory.CreateLogger(ex?.Source ?? nameof(ExceptionHandlingMiddleware)).LogError(0, ex, " ");
            }
        }
    }
}
