using Ardalis.GuardClauses;
using DroneStore.Core.Entities.Discounts;
using DroneStore.Data;
using System.Collections.Generic;

namespace DroneStore.Services.Services.Discounts
{
	public class DiscountService : IDiscountService
	{
		private readonly IRepository<Discount> _discountRep;

		public DiscountService(IRepository<Discount> discountRep)
		{
			_discountRep = discountRep;
		}

		public void Delete(Discount discount)
		{
			Guard.Against.Null(discount, nameof(discount));

			_discountRep.Delete(discount);
		}

		public IEnumerable<Discount> GetAll() =>
			_discountRep.EntitiesReadOnly;

		public Discount GetById(int discountId) =>
			_discountRep.GetById(discountId);

		public void Insert(Discount discount)
		{
			Guard.Against.Null(discount, nameof(discount));

			_discountRep.Insert(discount);
		}

		public void Update(Discount discount)
		{
			Guard.Against.Null(discount, nameof(discount));

			_discountRep.Update(discount);
		}
	}
}
