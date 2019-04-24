namespace Qualysoft.Evaluation.Application.UnitTests
{
    using Qualysoft.Evaluation.Application.Dto;
    using Qualysoft.Evaluation.Application.Xml;
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.IO;
    using Xunit;

    public class RequestXmlSerializerTests
    {
        private readonly DomainToXmlSerializedRequestMapper mapper;

        #region Should split this into separate tests for each serializer type

        private readonly BaseRequestXmlSerializer<string> requestStringXmlSerializer;
        private readonly BaseRequestXmlSerializer<ProduceXmlDto> appDataFileRequestXmlSerializer;

        #endregion

        public RequestXmlSerializerTests()
        {
            mapper = new DomainToXmlSerializedRequestMapper();
            requestStringXmlSerializer = new RequestStringXmlSerializer(mapper);
            appDataFileRequestXmlSerializer = new AppDataFileRequestXmlSerializer(mapper);
        }

        [Fact]
        public void ToStringShouldNotSerializeVisitsWhenNotSpecified()
        {
            SerializeRequestAndAssert(requestStringXmlSerializer, Defines.NullVisitsRequest() , o =>
            {
                string s = Assert.IsType<string>(o);
                Assert.NotNull(s);
                Assert.DoesNotContain("<visits>", s);
                Assert.DoesNotContain("</visits>", s);
                Assert.Contains("<ix>13</ix>", s);
                Assert.Contains($"<name>{Defines.VISITS_NOT_SPECIFIED}</name>", s);
                Assert.Contains("<dateRequested>2000-01-01</dateRequested>", s);
            });
        }

        [Fact]
        public void ToStringShouldSerializeVisitsWhenSpecified()
        {
            SerializeRequestAndAssert(requestStringXmlSerializer, Defines.FullRequest() , o =>
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
            var request = Defines.NullVisitsRequest();
            var fullPath = $@"App_Data\xml\{request.GetDateString()}.xml";
            var dto = appDataFileRequestXmlSerializer.Persist(request);
            
            Assert.NotNull(dto);
            Assert.Contains(dto.FileName, fullPath);
            Assert.True(dto.StreamLength > 0);

            var content = File.ReadAllText(fullPath);
            Assert.DoesNotContain("<visits>", content);
            Assert.DoesNotContain("</visits>", content);
        }

        [Fact]
        public void AppDataShouldSerializeVisitsWhenSpecified()
        {
            SerializeRequestAndAssert(appDataFileRequestXmlSerializer, Defines.FullRequest(), o => Assert.NotNull(o));
        }

        private void SerializeRequestAndAssert<T>(
            BaseRequestXmlSerializer<T> srlz,
            Request request,
            Action<dynamic> assertAction)
        {
            object o = srlz.InternalPersist(request);

            // assert output is ..
            assertAction(o);
        }
    }   
}
