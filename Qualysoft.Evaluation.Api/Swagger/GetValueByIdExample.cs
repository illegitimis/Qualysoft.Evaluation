namespace Qualysoft.Evaluation.Api.Swagger
{
using Swashbuckle.AspNetCore.Filters;

    internal class GetValueByIdExample : IExamplesProvider
    {
        public object GetExamples() => 13;
        /*{
            return new int[2] { 13, 999 }; 
        }*/
    }
}