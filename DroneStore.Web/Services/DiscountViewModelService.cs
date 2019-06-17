using DroneStore.Services.Services.Discounts;
using DroneStore.Web.Models.Discount;

namespace DroneStore.Web.Services
{
	public class DiscountViewModelService : IDiscountViewModelService
	{
		private readonly IDiscountService _discountService;

		public DiscountViewModelService(IDiscountService discountService)
		{
			_discountService = discountService;
		}

		public DiscountViewModel GetById(int dicountId)
		{
			var discount = _discountService.GetById(dicountId);

			if (discount == null) return null;

			var discountVM = new DiscountViewModel
			{
				DiscountId = discount.Id,
				ExpireDate = discount.ExpireDateInUtc,
				NewPrice = discount.NewValue,
				OldPrice = discount.OldValue,
				StartDate = discount.StartDateInUtc
			};
			return discountVM;
		}
	}
}
