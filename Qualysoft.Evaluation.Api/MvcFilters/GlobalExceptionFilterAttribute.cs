namespace Qualysoft.Evaluation.Api
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Qualysoft.Evaluation.Api.ActionResults;
    using Qualysoft.Evaluation.Application;
    using System.Threading.Tasks;

    using static Microsoft.AspNetCore.Http.StatusCodes;

    /// <summary />
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment env;

        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary />
        public GlobalExceptionFilterAttribute(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary />
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var task = base.OnExceptionAsync(context);

            return task.ContinueWith(t =>
            {
                HandleAdditionalActions(context);

                context.HttpContext.Response.Headers["TraceId"] = httpContextAccessor.HttpContext.TraceIdentifier;

                switch (context.Exception)
                {
                    case EnvironmentMismatchException exception:
                    {
                        var json = new JsonErrorResponse(exception.Message);
                        context.Result = new NotImplemented501ObjectResult(json);
                        context.HttpContext.Response.StatusCode = Status501NotImplemented;
                        break;
                    }

                    default:
                    {
                        var json = new JsonErrorResponse("An unknown error occured.");
                        if (env.IsDevelopment() || env.IsEnvironment(ConfigurationHelper.Development))
                        {
                            json.DeveloperMessage = context.Exception;
                        }

                        context.Result = new InternalServerError500ObjectResult(json);
                        context.HttpContext.Response.StatusCode = Status500InternalServerError;
                        break;
                    }
                }

                context.ExceptionHandled = true;
            });
        }

        /// <summary />
        protected virtual void HandleAdditionalActions(ExceptionContext context)
        {
        }
    }
}