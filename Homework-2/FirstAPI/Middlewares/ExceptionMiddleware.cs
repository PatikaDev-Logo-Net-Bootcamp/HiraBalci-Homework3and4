using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Bootcamp_Odev_2.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //swagger veya postmandan request olarak gönderilen path login veya register ise pipeline olarak devam edecektir
            var appVersion = new Version(_configuration.GetValue<string>("app-version"));
            var inputVersion = new Version(httpContext.Request.Headers["app-version"]);

            try
            {
                if (httpContext.Request.Path == "/register" || httpContext.Request.Path == "/login")
                {
                    await _next(httpContext);
                }
                else if (appVersion.CompareTo(inputVersion) > 0)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("401 Unauthorized Error!");
                }
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            
        }

       

        private async Task HandleExceptionAsync(HttpContext httpContext,Exception exception)
        {
            //  if (httpContext.Request.Path == "/api/login") //bir api oluştururum
            //  if(httpContext.Request.Method=="POST")//gelen request post ise git bunu yap

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsync("Error! " + exception.Message);
        }
    }


    
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
