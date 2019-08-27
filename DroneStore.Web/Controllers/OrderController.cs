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
        private readonly IShoppingCartViewModelService _shoppingCartService;

        public OrderController(IOrderViewModelService orderService,
            IShoppingCartViewModelService shoppingCartService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult SessionCartOrder() =>
            View(_orderService.PrepareSessionCartOrder());

        [HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult SessionCartOrder(OrderViewModel order)
        {
            var validator = new OrderValidator();
            var validationResult = validator.Validate(order);

            if (!validationResult.IsValid)
            {
                var model = _orderService.PrepareSessionCartOrder();

                foreach (var error in validationResult.Errors)
                {
                    model.Errors.Add(error.ToString());
                }

                return View(model);
            }

            int orderId = _orderService.AddOrder(order);
            _shoppingCartService.Cart.Lines.Clear();

            ViewData["orderId"] = orderId;

            return View("Success");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveOrder(int orderId)
        {
            _orderService.RemoveOrder(orderId);

            return View("Cancel");
        }
    }
}