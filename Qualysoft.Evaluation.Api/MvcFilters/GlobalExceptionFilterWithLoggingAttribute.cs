namespace Qualysoft.Evaluation.Api.Filters
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class GlobalExceptionFilterWithLoggingAttribute : GlobalExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilterWithLoggingAttribute> logger;

        public GlobalExceptionFilterWithLoggingAttribute(
            IHostingEnvironment env,
            IHttpContextAccessor httpContextAccessor,
            ILogger<GlobalExceptionFilterWithLoggingAttribute> logger)
            : base(env, httpContextAccessor)
        {
            this.logger = logger;
        }

        protected override void HandleAdditionalActions(ExceptionContext context)
        {
            logger.LogError(context.Exception.GetBaseException(), nameof(GlobalExceptionFilterWithLoggingAttribute.HandleAdditionalActions));
        }
    }
}
