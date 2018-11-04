namespace Qualysoft.Evaluation.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    /// <summary>test api is up and running</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        /// <summary>test api ping for up and running</summary>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), Status200OK)]
        [SwaggerResponse(Status200OK, "OK 200", typeof(void))]
        [ProducesResponseType(Status302Found)]
        [SwaggerResponse(Status302Found, "Exception middleware redirects to error pages", typeof(void))]
        public ActionResult Get() => Ok();
    }
}