namespace Qualysoft.Evaluation.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Domain;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Threading.Tasks;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    /// <summary>api/jobs</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IAsyncRepository<Request, int> requestRepository;
        private readonly ISerializeXml xmlSerializer;
        private readonly IBackgroundJobRunner backgroundJobRunner;

        /// <summary>ctor</summary>
        /// <param name="requestRepo">injected request repo</param>
        /// <param name="serializer">injected xml serializer</param>
        /// <param name="jobber">Background Job Runner</param>
        public JobsController(
            IAsyncRepository<Request, int> requestRepo,
            ISerializeXml serializer,
            IBackgroundJobRunner jobber)
        {
            requestRepository = requestRepo;
            xmlSerializer = serializer;
            backgroundJobRunner = jobber;
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

            foreach (var request in requests)
            {
                await backgroundJobRunner.Enqueue(() => xmlSerializer.Persist(request));
            }

            return Ok();
        }
    }
}