namespace Qualysoft.Evaluation.Api.ActionResults
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary />
    public class InternalServerError500ObjectResult : ObjectResult
    {
        /// <summary />
        public InternalServerError500ObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
