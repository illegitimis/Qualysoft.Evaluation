namespace Qualysoft.Evaluation.Api.IntegrationTests
{
    using Microsoft.AspNetCore.TestHost;
    using System;
    using System.Net.Http;

    public sealed class ServerTestHostFixture
        : IDisposable
    {
        readonly TestServer testServer;
        readonly HttpClient apiClient;

        public TestServer TestServer => testServer;
        public HttpClient ApiClient => apiClient;

        public ServerTestHostFixture()
        {
            var webHostBuilder = Program.CreateWebHostBuilder(new string[0]);
            testServer = new TestServer(webHostBuilder);
            apiClient = testServer.CreateClient();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeManagedState();
                }

                FreeUnmanagedResources();

                disposedValue = true;
            }
        }


        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ServerTestHostFixture() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        private void DisposeManagedState()
        {
            apiClient.Dispose();
            testServer.Dispose();
        }

        /// <summary>
        ///   Free unmanaged resources (unmanaged objects) and override a finalizer below.
        ///   set large fields to null.
        /// </summary>
        private void FreeUnmanagedResources()
        {
            // no unmanaged resources to dispose
        }

        #endregion

    }
}
