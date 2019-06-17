using DroneStore.Core.Entities.Discounts;
using System.Collections.Generic;

namespace DroneStore.Services.Services.Discounts
{
	public interface IDiscountService
	{
		IEnumerable<Discount> GetAll();
		void Delete(Discount discount);
		void Update(Discount discount);
		void Insert(Discount discount);
		Discount GetById(int discountId);
	}
}
