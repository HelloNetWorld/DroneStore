using DroneStore.Services.Services.Orders;
using DroneStore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderController(IOrderService orderService,
            IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        // GET: Order
        public IActionResult Index()
        {
            var model = _orderService.GetAll();
            return View(model);
        }

        // GET: Order/Details/5
        public IActionResult Details(int id)
        {
            var order = _orderService.GetById(id);
            var orderItems = _orderItemService.GetOrderItemsByOrderId(order.OrderId);

            var model = new OrderDetailsViewModel
            {
                Order = order,
                Items = orderItems
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var order = _orderService.GetById(id);
            _orderService.Delete(order);

            var orderItems = _orderItemService.GetOrderItemsByOrderId(order.OrderId);
            foreach(var item in orderItems)
            {
                _orderItemService.Delete(item);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}