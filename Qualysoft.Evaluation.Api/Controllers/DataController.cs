namespace Qualysoft.Evaluation.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Qualysoft.Evaluation.Api.MvcFilters;
    using Qualysoft.Evaluation.Api.Swagger;
    using Qualysoft.Evaluation.Application;
    using Swashbuckle.AspNetCore.Annotations;
    using Swashbuckle.AspNetCore.Filters;
    using System.Collections.Generic;
    using System.Linq;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    /// <summary>Data controller</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IRequestService requestService;

        /// <summary>ctor</summary>
        /// <param name="requestService">request service</param>
        public DataController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        /// <summary>POST /api/data</summary>
        /// <param name="requestDtos">collection of request models</param>
        /// <remarks>
        /// This endpoint receives a collection of serialized JSON models and stores them in a database created using automated database migrations.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(RequestPostResponse), Status200OK)]
        [SwaggerResponse(Status200OK, "OK 200", typeof(RequestPostResponse))]
        [ProducesResponseType(typeof(string), Status400BadRequest)]
        [SwaggerResponse(Status400BadRequest, "400 Bad Request", typeof(string))]
        [ProducesResponseType(typeof(JsonErrorResponse), Status500InternalServerError)]
        [SwaggerResponse(Status500InternalServerError, "500 Internal Server Error", typeof(JsonErrorResponse))]
        [SwaggerRequestExample(typeof(IReadOnlyCollection<RequestModel>), typeof(RequestModelCollectionExample))]
        [ValidateModelStateAttribute]
        public IActionResult Post([FromBody] IReadOnlyCollection<RequestModel> requestDtos) => 
            (requestDtos == null || !requestDtos.Any())
                ? (IActionResult)BadRequest(nameof(requestDtos))
                : Ok(requestService.Upsert(requestDtos));

        /// <summary>GET api/data</summary>
        /// <remarks>ping api</remarks>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), Status200OK)]
        [SwaggerResponse(Status200OK, "OK 200", typeof(void))]
        public ActionResult Ping() => Ok();
    }
}