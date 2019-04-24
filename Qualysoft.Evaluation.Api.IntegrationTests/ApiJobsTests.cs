namespace Qualysoft.Evaluation.Api.IntegrationTests
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class ApiJobsTests : ServerTestHostBase
    {
        const string ApiJobsSaveFiles = "/api/Jobs/saveFiles";

        public ApiJobsTests(ServerTestHostFixture serverTestHostFixture) : base(serverTestHostFixture)
        {
        }

        [Fact]
        public async Task PositiveTestJobsSaveFiles()
        {
            // act
            apiClient.DefaultRequestHeaders.Remove("Accept");
            apiClient.DefaultRequestHeaders.Add("Accept", "application/json");
            // apiClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            var httpResponseMessage = await apiClient.GetAsync(ApiJobsSaveFiles);

            // assert status
            Assert.NotNull(httpResponseMessage);
            Assert.True(httpResponseMessage.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        }
    }
}
