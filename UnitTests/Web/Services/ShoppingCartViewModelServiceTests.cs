using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DroneStore.Services.Catalog;
using DroneStore.Web.Models.ShoppingCart;
using DroneStore.Web.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace UnitTests.Web.Services
{
    public class ShoppingCartViewModelServiceTests
    {
        private readonly Mock<ICatalogService> _catalogService;
        private readonly Mock<IHttpContextAccessor> _httpContext;

        public ShoppingCartViewModelServiceTests()
        {
            _catalogService = new Mock<ICatalogService>();
            _httpContext = new Mock<IHttpContextAccessor>();

            var context = new DefaultHttpContext();
            _httpContext.Setup(x => x.HttpContext).Returns(context);
        }

        //[Fact]
        //public void Returns_Empty_Cart()
        //{
        //    _httpContext.Setup(x => x.HttpContext.Session.Get(It.IsAny<string>()))
        //        .Returns((byte[])null);

        //    var service = new ShoppingCartViewModelService(
        //        _catalogService.Object, _httpContext.Object);

        //    var result = service.Cart;

        //    Assert.Empty(result.Lines);
        //    Assert.Equal(0, result.Total);
        //    Assert.Equal(0, result.SubTotal);
        //    Assert.Equal(0, result.Discount);
        //    Assert.Equal(string.Empty, result.BackUrl);
        //}
    }
}
