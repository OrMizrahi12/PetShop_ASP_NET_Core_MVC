using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace PetShopApiServise.Attributes.ExeptionAttributes
{
    public class PetShopExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpRequestException exception)
            {
                if (exception.StatusCode == HttpStatusCode.NotFound)
                {
                    context.Result = new NotFoundObjectResult("Animals not found.");
                }
                else if (exception.StatusCode == HttpStatusCode.InternalServerError)
                {
                    context.Result = new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
                else if(exception.StatusCode == HttpStatusCode.Unauthorized)
                {
                    context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                }
                else if(exception.StatusCode == HttpStatusCode.BadRequest)
                {
                    context.Result = new BadRequestObjectResult("Invalid animal data.");
                }
                else if(exception.StatusCode == HttpStatusCode.Forbidden)
                {
                    context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                }
                else
                {
                    context.Result = new BadRequestObjectResult("Failed.");
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult("Failed to retrieve animals.");
            }

            context.ExceptionHandled = true;
        }
    }
}
