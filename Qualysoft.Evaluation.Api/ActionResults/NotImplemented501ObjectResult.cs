namespace Qualysoft.Evaluation.Api.ActionResults
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary />
    public class NotImplemented501ObjectResult : ObjectResult
    {
        /// <summary />
        public NotImplemented501ObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status501NotImplemented;
        }
    }
}
