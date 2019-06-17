using System.Linq;
using DroneStore.Services.Catalog;
using DroneStore.Services.Services.Discounts;
using DroneStore.Web.Extensions;
using DroneStore.Web.Models.ShoppingCart;
using Microsoft.AspNetCore.Http;

namespace DroneStore.Web.Services
{
	public class ShoppingCartViewModelService : IShoppingCartViewModelService
	{
		private readonly ICatalogService _catalogService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IDiscountService _discountService;

		public ShoppingCartViewModelService(ICatalogService catalogService,
			IHttpContextAccessor httpContextAccessor,
			IDiscountService discountService)
		{
			_catalogService = catalogService;
			_httpContextAccessor = httpContextAccessor;
			_discountService = discountService;
			Cart = httpContextAccessor.HttpContext.Session?
				.Get<ShoppingCartViewModel>("ShoppingCart") ?? new ShoppingCartViewModel();
		}

		public ShoppingCartViewModel Cart { get; }

		public void AddToCard(int itemId, int quantity, string backUrl)
		{
			var item = _catalogService.GetById(itemId);
			if (item == null) return;

			var line = Cart.Lines.FirstOrDefault(i => i.Id == itemId);

			if (line == null)
			{
				var cartLine = new ShoppingCartLineViewModel
				{
					Id = item.Id,
					ImageId = item.ImageId,
					Name = item.Name,
					Quantity = quantity,
				};

				if (item.DiscountId.HasValue)
				{
					var discount = _discountService.GetById(item.DiscountId.Value);
					cartLine.Price = discount.NewValue;
					cartLine.DiscountValue = discount.OldValue - discount.NewValue;
				}
				else
				{
					cartLine.Price = item.Price;
				}

				Cart.Lines.Add(cartLine);
			}
			else
			{
				line.Quantity += quantity;
			}
			Cart.BackUrl = backUrl;
			SaveCart();
		}

		public void Clear()
		{
			Cart.Lines.Clear();
			SaveCart();
		}

		public void RemoveFromCard(int itemId, int quantity, string backUrl)
		{
			var item = _catalogService.GetById(itemId);
			if (item == null) return;

			var line = Cart.Lines.FirstOrDefault(i => i.Id == itemId);
			if (line == null) return;

			line.Quantity -= quantity;
			if (line.Quantity <= 0)
				Cart.Lines.Remove(line);

			Cart.BackUrl = backUrl;
			SaveCart();
		}

		public void ChangeQuantity(int itemId, int quantity, string backUrl)
		{
			var line = Cart.Lines.FirstOrDefault(i => i.Id == itemId);
			if (line == null) return;

			line.Quantity += quantity;
			Cart.BackUrl = backUrl;

			if (line.Quantity <= 0)
			{
				Cart.Lines.Remove(line);
			}

			SaveCart();
		}

		private void SaveCart() =>
			_httpContextAccessor.HttpContext.Session.Set("ShoppingCart", Cart);
	}
}
