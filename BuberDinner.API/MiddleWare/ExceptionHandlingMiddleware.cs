using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.ENUM;
using BuberDinner.Domain.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace BuberDinner.API.MiddleWare
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        private static string requestBody;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                requestBody = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                ;
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessageObject = new Error(ErrorCodes.InternalServerError);
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var ss = JsonConvert.DeserializeObject<AuthenticationResponse>(requestBody);

            var d = ex as BuberException;




            switch (ex)
            {
                case BuberException:
                    errorMessageObject.Message = ex.Message;
                    statusCode = Convert.ToInt32(d?.StatusCode);
                    errorMessageObject.StatusCode = statusCode;
                    break;
            }

            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;


            return context.Response.WriteAsync(errorMessage);
        }


    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
