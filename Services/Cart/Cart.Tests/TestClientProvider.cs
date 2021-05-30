using Cart.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cart.Tests
{
    public class TestClientProvider : IDisposable
    {
        private TestServer server;

        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup(typeof(Startup)));
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
