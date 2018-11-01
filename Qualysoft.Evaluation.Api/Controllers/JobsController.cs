namespace Qualysoft.Evaluation.Api.Controllers
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
    using Qualysoft.Evaluation.Domain;
    using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.AspNetCore.Http.StatusCodes;

    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IAsyncRepository<Request, int> requestRepository;

        public JobsController(IAsyncRepository<Request, int> requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        /// <summary>
        /// Invokes an internal job of selecting the database records and then serializes each table record as an XML file.
        /// </summary>
        /// <returns></returns>
        [HttpGet("saveFiles")]
        [ProducesResponseType(typeof(void), Status200OK)]
        [SwaggerResponse(Status200OK, "OK 200", typeof(void))]
        public async Task<ActionResult> SaveFiles()
        {
            var requests = await requestRepository.GetAllAsync();


            return Ok();
        }
    }
}