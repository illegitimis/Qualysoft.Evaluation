namespace Qualysoft.Evaluation.Application.UnitTests
{
    using Qualysoft.Evaluation.Domain;
    using System.Collections.Generic;
    using Xunit;

    public class DomainToXmlSerializedRequestMapperTest
    {
        private readonly IClassMapper<Request, CT_XSD_Request> mapper;

        public DomainToXmlSerializedRequestMapperTest()
        {
            mapper = new DomainToXmlSerializedRequestMapper();
        }

        [Theory]
        [MemberData(nameof(GetRequests))]
        public void ShouldMapDomainRequestToXsdRequest(Request req)
        {
            var xsdRequest = mapper.Map(req);
            Assert.Equal(xsdRequest.Index, req.Index);
            Assert.Equal(xsdRequest.Content.Date, req.Date);
            Assert.Equal(xsdRequest.Content.Name, req.Name);
            if (req.Visits.HasValue)
            {
                Assert.Equal(xsdRequest.Content.Visits, req.Visits);
            }
            else
            {
                Assert.False(xsdRequest.Content.VisitsSpecified);
            }
        }

        public static IEnumerable<object[]> GetRequests()
        {
            yield return new object[] { Defines.NullVisitsRequest() };
            yield return new object[] { Defines.FullRequest() };
        }
    }
}
