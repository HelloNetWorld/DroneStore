using System.Net.Http;
using DroneStore.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Threading.Tasks;
using System.Net;

namespace FunctionalTests.Web
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Returns_Home_PageAsync()
        {
            var response = await _client.GetAsync("/");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Returns_Privacy_PageAsync()
        {
            var response = await _client.GetAsync("/Home/Privacy");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
