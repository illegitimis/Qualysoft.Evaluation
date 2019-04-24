namespace Qualysoft.Evaluation.Api.IntegrationTests
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class SwaggerTests : ServerTestHostBase
    {
        public SwaggerTests(ServerTestHostFixture serverTestHostFixture)
            : base(serverTestHostFixture)
        {
        }

        [Fact]
        public void TestServerCreation()
        {
            Assert.NotNull(testServer);
            Assert.NotNull(apiClient);
        }

        [Fact]
        public async Task SwaggerUIShouldGetGeneratedAtRouteBase()
        {
            var httpResponseMessage = await apiClient.GetAsync("index.html");
            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
            var body = await httpResponseMessage.Content.ReadAsStringAsync();
            Assert.Contains("<title>A simple ASP.NET Core Web API</title>", body);
        }
    }
}
