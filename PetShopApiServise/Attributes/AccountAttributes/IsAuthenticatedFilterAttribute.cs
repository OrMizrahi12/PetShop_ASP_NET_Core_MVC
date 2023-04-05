using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PetShopApiServise.Attributes.AccountAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IsAuthenticatedFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity!.IsAuthenticated)
            {
                context.Result = new JsonResult(new { error = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
