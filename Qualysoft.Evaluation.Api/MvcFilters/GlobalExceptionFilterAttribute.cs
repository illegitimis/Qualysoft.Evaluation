namespace Qualysoft.Evaluation.Api
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Qualysoft.Evaluation.Api.ActionResults;
    using Qualysoft.Evaluation.Application;
    using System.Threading.Tasks;

    using static Microsoft.AspNetCore.Http.StatusCodes;

    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment env;

        private readonly IHttpContextAccessor httpContextAccessor;

        public GlobalExceptionFilterAttribute(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var task = base.OnExceptionAsync(context);

            return task.ContinueWith(t =>
            {
                HandleAdditionalActions(context);

                context.HttpContext.Response.Headers["TraceId"] = httpContextAccessor.HttpContext.TraceIdentifier;

                switch (context.Exception)
                {
                    /*
                    case RequestValidationException exception:
                        {
                            var json = new JsonErrorResponse(exception.ValidationErrors);
                            context.Result = new BadRequestObjectResult(json);
                            context.HttpContext.Response.StatusCode = Status400BadRequest;
                            break;
                        }

                    case QueryException exception:
                        {
                            var json = new JsonErrorResponse(exception.Errors);
                            context.Result = (exception.ErrorCode == QueryErrorCode.NotFound)
                                ? (IActionResult)new NotFoundObjectResult(json)
                                : (IActionResult)new BadRequestObjectResult(json);
                            context.HttpContext.Response.StatusCode = (exception.ErrorCode == QueryErrorCode.NotFound) ? Status404NotFound : Status400BadRequest;
                            break;
                        }

                    case OptimisticConcurrencyException exception:
                        {
                            var json = new JsonErrorResponse(exception.Message);
                            context.Result = new PreconditionFailedObjectResult(json);
                            context.HttpContext.Response.StatusCode = Status412PreconditionFailed;
                            break;
                        }

                    case UnitAuthorizationException exception:
                        {
                            var json = new JsonErrorResponse(exception.Message);
                            context.Result = new ForbiddenObjectResult(json);
                            context.HttpContext.Response.StatusCode = Status403Forbidden;
                            break;
                        }

                    case FMOBusinessException exception:
                        {
                            var json = new JsonErrorResponse(exception.Message);
                            context.Result = new BadRequestObjectResult(json);
                            context.HttpContext.Response.StatusCode = Status417ExpectationFailed;
                            break;
                        }
                        */
                    default:
                        {
                            var json = new JsonErrorResponse("An unknown error occured.");
                            if (env.IsDevelopment() || env.IsEnvironment(ConfigurationHelper.Development))
                            {
                                json.DeveloperMessage = context.Exception;
                            }

                            context.Result = new InternalServerErrorObjectResult(json);
                            context.HttpContext.Response.StatusCode = Status500InternalServerError;
                            break;
                        }
                }

                context.ExceptionHandled = true;
            });
        }

        protected virtual void HandleAdditionalActions(ExceptionContext context)
        {
        }
    }
}