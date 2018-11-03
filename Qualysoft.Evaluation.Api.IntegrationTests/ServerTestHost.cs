namespace Qualysoft.Evaluation.Api.IntegrationTests
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Newtonsoft.Json;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Data;
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ServerTestHost
    {
        const string ApiData = "/api/Data";
        const string ApiJobsSaveFiles = "/api/Jobs/saveFiles";
        const string mediaTypeJson = "application/json";

        readonly TestServer testServer;
        readonly HttpClient apiClient;

        public ServerTestHost()
        {
            /*
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory());
            webHostBuilder.UseStartup<Startup>();
            */
            var webHostBuilder = Program.CreateWebHostBuilder(new string[0]);
            testServer = new TestServer(webHostBuilder);
            apiClient = testServer.CreateClient();
        }

        [Fact]
        public void TestServerCreation()
        {
            Assert.NotNull(testServer);
            Assert.NotNull(apiClient);
        }

        [Fact]
        public async Task PositivePostDataTestWithSingleItemCollection()
        {
            // arrange
            var request = new RequestModel { Index = 0, Date = DateTime.UtcNow, Name = "name 1326" };
            var requests = new List<RequestModel>(new[] { request }).AsReadOnly();
            string json = JsonConvert.SerializeObject(requests);
            var stringContent = new StringContent(json, Encoding.UTF8, mediaTypeJson);

            // act
            var httpResponseMessage = await apiClient.PostAsync(ApiData, stringContent);

            // assert status
            Assert.NotNull(httpResponseMessage);
            Assert.True(httpResponseMessage.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);

            // Assert response body
            var body = await httpResponseMessage.Content.ReadAsStringAsync();
            var postResponse = JsonConvert.DeserializeObject<RequestPostResponse>(body);
            Assert.Equal(1, postResponse.Added + postResponse.Updated);
        }

        [Fact]
        public async Task PostEmptyStringReturnsBadRequest()
        {
            // arrange
            var stringContent = new StringContent(string.Empty, Encoding.UTF8, mediaTypeJson);

            // act
            var httpResponseMessage = await apiClient.PostAsync(ApiData, stringContent);

            // assert status
            Assert.NotNull(httpResponseMessage);
            Assert.False(httpResponseMessage.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponseMessage.StatusCode);

            // Assert response body
            var body = await httpResponseMessage.Content.ReadAsStringAsync();
            Assert.Equal("{\"\":[\"A non-empty request body is required.\"]}", body);
        }

        [Fact]
        public async Task PostDataMalformedJsonReturnsBadRequest()
        {
            // arrange, intentionally removed properties from serialized BogusDataGenerator.RequestDtos(3)
            string json = "[{\"name\":\"Sean Kovacek\",\"visits\":-1777760828,\"date\":\"2018-01-28T10:20:12.7055562+02:00\"},{\"ix\":1,\"date\":\"2018-03-19T23:30:45.7116295+02:00\"},{\"ix\":2,\"name\":\"Savanna Spinka\"}]";
            var stringContent = new StringContent(json, Encoding.UTF8, mediaTypeJson);

            // act
            var httpResponseMessage = await apiClient.PostAsync(ApiData, stringContent);

            // assert status
            Assert.NotNull(httpResponseMessage);
            Assert.False(httpResponseMessage.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponseMessage.StatusCode);

            // Assert response body
            var body = await httpResponseMessage.Content.ReadAsStringAsync();
            Assert.Contains("Required property 'ix' not found in JSON.", body);
            Assert.Contains("Required property 'name' not found in JSON", body);
            Assert.Contains("Required property 'date' not found in JSON", body);
        }

        [Fact]
        public async Task GivenNoPostDataThenBadRequest()
        {
            // arrange
            var stringContent = new StringContent("[]", Encoding.UTF8, mediaTypeJson);

            // act
            var httpResponseMessage = await apiClient.PostAsync(ApiData, stringContent);

            // assert status
            Assert.NotNull(httpResponseMessage);
            Assert.False(httpResponseMessage.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponseMessage.StatusCode);

            // Assert response body
            var body = await httpResponseMessage.Content.ReadAsStringAsync();
            Assert.Equal("requestDtos", body);
        }
    }
}
