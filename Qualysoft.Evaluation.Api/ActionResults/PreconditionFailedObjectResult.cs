namespace Qualysoft.Evaluation.Api.ActionResults
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class PreconditionFailedObjectResult : ObjectResult
    {
        public PreconditionFailedObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status412PreconditionFailed;
        }
    }
}
