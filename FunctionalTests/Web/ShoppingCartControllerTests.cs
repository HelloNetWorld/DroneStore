using System.Net.Http;
using DroneStore.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Threading.Tasks;
using System.Net;

namespace FunctionalTests.Web
{
    public class ShoppingCartControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ShoppingCartControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Returns_ShoppingCart_PageAsync()
        {
            var response = await _client.GetAsync("/ShoppingCart");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
