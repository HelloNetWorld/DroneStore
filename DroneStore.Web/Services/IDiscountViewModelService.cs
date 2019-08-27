using DroneStore.Web.Models.Discount;

namespace DroneStore.Web.Services
{
	public interface IDiscountViewModelService
	{
		DiscountViewModel GetById(int dicountId);
        bool HasDiscount(int? discountId);
	}
}
