using System;
using System.Collections.Generic;
using System.Text;
using DroneStore.Web.Controllers;
using Xunit;
using DroneStore.Web.Services;
using Moq;

namespace UnitTests.Web.Controllers
{
    public class OrderControllerTests
    {

        private readonly Mock<IOrderViewModelService> _orderService;

        public OrderControllerTests()
        {
            _orderService = new Mock<IOrderViewModelService>();
        }

        //private OrderViewModel

        //[Fact]
        //public void Can_Add_Order()
        //{

        //    _orderService.Setup(x=>x.AddOrder(null)).Returns(14)
        //    var controller = new OrderController()
        //}
    }
}
