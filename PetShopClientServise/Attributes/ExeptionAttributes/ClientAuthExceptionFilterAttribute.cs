using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Attributes.ExeptionAttributes
{
    public class ClientAuthExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly string _viewName;

        public ClientAuthExceptionFilterAttribute(string viewName)
        {
            _viewName = viewName;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpException exception)
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult
                {
                    ViewName = _viewName,
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState) { { "Status", exception.StatusCode } }
                };
            }
            else
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult
                {
                    ViewName = _viewName,
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState) { { "Status", "Something went wrong." } }
                };
            }
        }
    }
}
