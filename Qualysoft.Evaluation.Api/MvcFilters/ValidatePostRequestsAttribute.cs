namespace Qualysoft.Evaluation.Api.MvcFilters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Qualysoft.Evaluation.Application;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ValidateModelStateAttributeAttribute : ActionFilterAttribute
    {
        public ValidateModelStateAttributeAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            /*
            if (context.Controller.GetType() == typeof(Controllers.DataController) &&
                context.ActionDescriptor.RouteValues["action"] == "Post" &&
                context.ActionDescriptor.RouteValues["controller"] == "Data" &&
                context.ActionArguments["requestDtos"] is IReadOnlyCollection<RequestModel> roc &&
                !roc.Any())
            {
                context.Result = new BadRequestObjectResult("requestDtos");
            }
            */
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
