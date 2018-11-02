namespace Qualysoft.Evaluation.Application.UnitTests
{
    using Qualysoft.Evaluation.Application.Dto;
    using Qualysoft.Evaluation.Application.Xml;
    using Qualysoft.Evaluation.Domain;
    using System;
    using Xunit;

    public class RequestXmlSerializerTests
    {
        const string v = "visits not specified";

        private readonly DomainToXmlSerializedRequestMapper mapper;

        #region Should split this into separate tests for each serializer type

        private readonly BaseRequestXmlSerializer requestStringXmlSerializer;
        private readonly BaseRequestXmlSerializer appDataFileRequestXmlSerializer;

        #endregion

        private readonly Request r1 = new Request
        {
            Index = 13,
            Name = v,
            Date = new DateTime(2000, 1, 1)
        };

        private readonly Request r2 = new Request
        {
            Index = 17,
            Name = "name",
            Date = new DateTime(2018, 5, 22),
            Visits = 13
        };


        public RequestXmlSerializerTests()
        {
            mapper = new DomainToXmlSerializedRequestMapper();
            requestStringXmlSerializer = new RequestStringXmlSerializer(mapper);
            appDataFileRequestXmlSerializer = new AppDataFileRequestXmlSerializer(mapper);
        }

        [Fact]
        public void ToStringShouldNotSerializeVisitsWhenNotSpecified()
        {
            SerializeRequestAndAssert(requestStringXmlSerializer, r1, o =>
            {
                string s = Assert.IsType<string>(o);
                Assert.NotNull(s);
                Assert.DoesNotContain("<visits>", s);
                Assert.DoesNotContain("</visits>", s);
                Assert.Contains("<ix>13</ix>", s);
                Assert.Contains($"<name>{v}</name>", s);
                Assert.Contains("<dateRequested>2000-01-01</dateRequested>", s);
            });
        }

        [Fact]
        public void ToStringShouldSerializeVisitsWhenSpecified()
        {
            SerializeRequestAndAssert(requestStringXmlSerializer, r2, o =>
            {
                string s = Assert.IsType<string>(o);
                Assert.Contains("<visits>13</visits>", s);
                Assert.Contains("<ix>17</ix>", s);
                Assert.Contains("<name>name</name>", s);
                Assert.Contains("<dateRequested>2018-05-22</dateRequested>", s);
            });
        }

        [Fact]
        public void AppDataShouldNotSerializeVisitsWhenNotSpecified()
        {
            SerializeRequestAndAssert(appDataFileRequestXmlSerializer, r1, o =>
            {
                Assert.NotNull(o);
                ProduceXmlDto dto = Assert.IsType<ProduceXmlDto>(o);
                Assert.Contains($@"App_Data\xml\{r1.GetDateString()}.xml", dto.FileName);
                Assert.True(dto.StreamLength > 0);
            });
        }

        [Fact]
        public void AppDataShouldSerializeVisitsWhenSpecified()
        {
            SerializeRequestAndAssert(appDataFileRequestXmlSerializer, r2, o => Assert.NotNull(o));
        }

        private void SerializeRequestAndAssert(
            BaseRequestXmlSerializer srlz,
            Request request,
            Action<dynamic> assertAction)
        {
            object o = srlz.InternalPersist(request);

            // assert output is ..
            assertAction(o);
        }
    }   
}
