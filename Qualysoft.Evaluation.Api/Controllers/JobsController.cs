namespace Qualysoft.Evaluation.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Application.Dto;
    using Qualysoft.Evaluation.Domain;
    using Swashbuckle.AspNetCore.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    /// <summary>api/jobs</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IAsyncRepository<Request, int> requestRepository;
        private readonly ISerializeXml<ProduceXmlDto> xmlSerializer;
        private readonly IBackgroundJobRunner backgroundJobRunner;

        /// <summary>ctor</summary>
        /// <param name="requestRepo">injected request repo</param>
        /// <param name="serializer">injected xml serializer</param>
        /// <param name="jobber">Background Job Runner</param>
        public JobsController(
            IAsyncRepository<Request, int> requestRepo,
            ISerializeXml<ProduceXmlDto> serializer,
            IBackgroundJobRunner jobber)
        {
            requestRepository = requestRepo;
            xmlSerializer = serializer;
            backgroundJobRunner = jobber;
        }

        /// <summary>Invokes an internal job of selecting the database records and then serializes each table record as an XML file.</summary>
        /// <remarks>Enqueued tasks could be fire and forget.</remarks>
        [HttpGet("saveFiles")]
        [ProducesResponseType(typeof(void), Status200OK, Type = typeof(ProduceXmlDto[]))]
        [SwaggerResponse(Status200OK, "OK 200", typeof(ProduceXmlDto[]))]
        public async Task<ActionResult> SaveFiles()
        {
            var requests = await requestRepository.GetAllAsync();

            var tasks = new List<Task<ProduceXmlDto>>();
            foreach (var request in requests)
            {
                Func<ProduceXmlDto> func = () => xmlSerializer.Persist(request);
                Task<ProduceXmlDto> xmlSerializeRequestTask = backgroundJobRunner.Enqueue<ProduceXmlDto>(func);
                tasks.Add(xmlSerializeRequestTask);
            }
            var dtos = await Task.WhenAll(tasks);

            return Ok(dtos);
        }
    }
}