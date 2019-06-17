using DroneStore.Web.Models.Order;
using DroneStore.Web.Services;
using DroneStore.Web.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Controllers
{
	[AllowAnonymous]
	public class OrderController : Controller
    {
        private readonly IOrderViewModelService _orderService;

        public OrderController(IOrderViewModelService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult SessionCartOrder()
        {
            var model = _orderService.PrepareSessionCartOrder();
            return View(model);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult AddOrder(OrderViewModel order)
        {
            var validator = new OrderValidator();
            var validationResult = validator.Validate(order);
            if (!validationResult.IsValid)
            {
                var model = _orderService.PrepareSessionCartOrder();
                foreach(var error in validationResult.Errors)
                {
                    model.ValidationErrors.Add(error.ToString());
                }

                return View("SessionCartOrder", model);
            }

            int orderId = _orderService.AddOrder(order);

            ViewData["orderId"] = orderId;

            return View("Success");
        }

        [HttpPost]
        public IActionResult RemoveOrder(int orderId)
        {
            _orderService.RemoveOrder(orderId);

            return View("Cancel");
        }
    }
}