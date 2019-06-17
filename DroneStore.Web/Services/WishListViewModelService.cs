using DroneStore.Services.Catalog;
using DroneStore.Web.Extensions;
using DroneStore.Web.Models.WishList;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace DroneStore.Web.Services
{
	public class WishListViewModelService : IWishListViewModelService
	{
		private readonly ICatalogService _catalogService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public WishListViewModelService(ICatalogService catalogService,
			IHttpContextAccessor httpContextAccessor)
		{
			_catalogService = catalogService;
			_httpContextAccessor = httpContextAccessor;
			WishList = httpContextAccessor.HttpContext.Session?
				.Get<WishListViewModel>("WishList") ?? new WishListViewModel();
		}

		public WishListViewModel WishList { get; }

		public void Add(int itemId)
		{
			var catalogItem = _catalogService.GetById(itemId);
			if (catalogItem == null) return;
			if (WishList.Items.Any(wli => wli.Id == itemId)) return;

			var wishListItem = new WishListItem
			{
				Id = catalogItem.Id,
				ImageId = catalogItem.ImageId,
				Name = catalogItem.Name,
				Price = catalogItem.Price
			};
			WishList.Items.Add(wishListItem);
			SaveWishList();
		}

		public void Remove(int itemId)
		{
			var wishListItem = WishList.Items
				.FirstOrDefault(wli => wli.Id == itemId);

			if (wishListItem == null) return;

			WishList.Items.Remove(wishListItem);
			SaveWishList();
		}

		private void SaveWishList() =>
			_httpContextAccessor.HttpContext.Session.Set("WishList", WishList);
	}
}
