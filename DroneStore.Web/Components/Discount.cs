using DroneStore.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class Discount : ViewComponent
	{
		private readonly IDiscountViewModelService _discountViewModelService;

		public Discount(IDiscountViewModelService discountViewModelService) =>
			_discountViewModelService = discountViewModelService;

		public IViewComponentResult Invoke(int itemId)
		{
			var discount = _discountViewModelService.GetById(itemId);

			return View(discount);
		}
	}
}
