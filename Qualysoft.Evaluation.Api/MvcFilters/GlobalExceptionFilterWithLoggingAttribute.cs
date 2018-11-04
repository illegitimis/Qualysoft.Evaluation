namespace Qualysoft.Evaluation.Api.Filters
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    /// <summary>MVC exception filter with logging</summary>
    public class GlobalExceptionFilterWithLoggingAttribute : GlobalExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilterWithLoggingAttribute> logger;

        /// <summary />
        /// <param name="env"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="logger"></param>
        public GlobalExceptionFilterWithLoggingAttribute(
            IHostingEnvironment env,
            IHttpContextAccessor httpContextAccessor,
            ILogger<GlobalExceptionFilterWithLoggingAttribute> logger)
            : base(env, httpContextAccessor)
        {
            this.logger = logger;
        }

        /// <summary />
        protected override void HandleAdditionalActions(ExceptionContext context)
        {
            logger.LogError(context.Exception.GetBaseException(), nameof(GlobalExceptionFilterWithLoggingAttribute.HandleAdditionalActions));
        }
    }
}
