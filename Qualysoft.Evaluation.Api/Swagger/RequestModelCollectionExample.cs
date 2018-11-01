namespace Qualysoft.Evaluation.Api.Swagger
{
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Data;
    using Swashbuckle.AspNetCore.Filters;
    using System.Collections.Generic;

    /// <summary>Example provider for Swagger UI</summary>
    /// <remarks>https://stackoverflow.com/questions/46875059/swaggerrequestexample-is-being-ignored</remarks>
    internal class RequestModelCollectionExample : IExamplesProvider
    {
        public object GetExamples() => RequestModelCollection();

        IReadOnlyCollection<RequestModel> RequestModelCollection() => new List<RequestModel>(BogusDataGenerator.RequestDtos(2)).AsReadOnly();
    }
}