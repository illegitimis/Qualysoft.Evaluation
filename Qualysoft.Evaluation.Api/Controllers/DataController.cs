namespace Qualysoft.Evaluation.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Qualysoft.Evaluation.Api.Models;

    /// <summary>
    /// Data controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        /// <summary>POST /api/data</summary>
        /// <param name="value">request model</param>
        /// <remarks>
        /// This endpoint receives a collection of serialized JSON models and stores them in a database created using automated database migrations.
        /// </remarks>
        [HttpPost]
        public void Post([FromBody] RequestModel value)
        {

        }
    }
}