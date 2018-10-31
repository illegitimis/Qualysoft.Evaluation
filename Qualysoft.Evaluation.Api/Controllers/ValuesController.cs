namespace Qualysoft.Evaluation.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Qualysoft.Evaluation.Api.Swagger;
    using Swashbuckle.AspNetCore.Annotations;
    using Swashbuckle.AspNetCore.Filters;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Microsoft.AspNetCore.Http.StatusCodes;


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>GET api/values</summary>
        /// <returns>string array</returns>
        /// <remarks>regular remarks</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(string[]), Status200OK)]
        [SwaggerResponse(Status200OK, "OK 200", typeof(string[]))]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>GET api/values/{id}</summary>
        /// <param name="id">id</param>
        /// <returns>string</returns>
        /// <remarks>
        /// <code>
        /// public class DeliveryOptionsSearchModelExample : IExamplesProvider
        /// {
        /// public object GetExamples()
        /// {
        /// return new DeliveryOptionsSearchModel
        /// {
        /// Lang = "en-GB", Currency = "GBP", 
        /// Address = new AddressModel { Address1 = "1 Gwalior Road", Locality = "London" }, 
        /// Items = new[] { new ItemModel {} } }; 
        /// }
        /// </code>
        /// </remarks>
        [HttpGet("{id}")]
        [SwaggerRequestExample(typeof(int), typeof(GetValueByIdExample))]
        public ActionResult<string> Get([FromRoute, Required]int id)
        {
            return "value";
        } 
    }
}
