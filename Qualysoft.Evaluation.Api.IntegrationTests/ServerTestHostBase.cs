namespace Qualysoft.Evaluation.Api.IntegrationTests
{
    using Microsoft.AspNetCore.TestHost;
    using Newtonsoft.Json;
    using Qualysoft.Evaluation.Application;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public abstract class ServerTestHostBase : IClassFixture<ServerTestHostFixture>
    {
        readonly ServerTestHostFixture _serverTestHostFixture;
        protected TestServer testServer;
        protected HttpClient apiClient;

        protected ServerTestHostBase(ServerTestHostFixture serverTestHostFixture)
        {
            _serverTestHostFixture = serverTestHostFixture;
            testServer = serverTestHostFixture.TestServer;
            apiClient = serverTestHostFixture.ApiClient;
        }
    }
}
