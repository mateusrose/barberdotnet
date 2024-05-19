using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace barberdotnet.controllers.middleware
{
    public class BlockRegisterMiddleware
    {
        private readonly RequestDelegate _next;

        public BlockRegisterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/register", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Register endpoint is disabled.");
                return;
            }

            await _next(context);
        }
    }
    public static class BlockRegisterMiddlewareExtensions
    {
        public static IApplicationBuilder UseBlockRegisterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BlockRegisterMiddleware>();
        }
    }

}