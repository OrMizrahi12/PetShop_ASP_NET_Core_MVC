using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace PetShopApiServise.Attributes.ExeptionAttributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PetShopExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is HttpException exception)
        {
            HttpStatusCode status = exception.StatusCode;

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(new
            {
                StatusCode = status,
                exception.Message
            }) 
            {
                StatusCode = (int)status
            };
        }
        else
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(new
            {
                StatusCode = status,
                context.Exception.Message,
                context.Exception.StackTrace
            })
            {
                StatusCode = (int)status
            };
        }
    }
}
public class HttpException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public HttpException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}
