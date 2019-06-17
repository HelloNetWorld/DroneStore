using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DroneStore.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FunctionalTests.Web
{
    public class CatalogControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CatalogControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Returns_Catalog_PageAsync()
        {
            var response = await _client.GetAsync("/Catalog");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
