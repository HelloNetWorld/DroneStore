using System;
using System.Collections.Generic;
using System.Linq;
using DroneStore.Core.Entities.Orders;
using DroneStore.Services.Catalog;
using DroneStore.Services.Services.Discounts;
using DroneStore.Services.Services.Orders;
using DroneStore.Web.Models.Order;

namespace DroneStore.Web.Services
{
    public class OrderViewModelService : IOrderViewModelService
    {
        private readonly IShoppingCartViewModelService _cartService;
        private readonly ICatalogService _catalogService;
        private readonly IOrderService _orderService;
		private readonly IDiscountService _discountService;

        public OrderViewModelService(IShoppingCartViewModelService cartService,
            ICatalogService catalogService,
			IOrderService orderService,
			IDiscountService discountService)
        {
            _cartService = cartService;
            _catalogService = catalogService;
            _orderService = orderService;
			_discountService = discountService;
        }

        public OrderViewModel PrepareSessionCartOrder()
        {
            var cart = _cartService.Cart;

            var cartItemIds = cart.Lines.Select(cl => cl.Id);
            var catalogItems = _catalogService.GetAll()
                .Where(ci => cartItemIds.Any(id => id == ci.Id));

            var orderViewModel = new OrderViewModel();
            orderViewModel.CreationDate = DateTime.Now.ToUniversalTime();
            orderViewModel.ItemsPreview = new OrderItemsPreviewViewModel();
            // Order items from db
            foreach(var catalogItem in catalogItems)
            {
                var orderItem = new OrderItemViewModel
                {
                    CreationDate = DateTime.Now.ToUniversalTime(),
                    Name = catalogItem.Name,
                    ItemId = catalogItem.Id,
                    Quantity = cart.Lines.Where(cl => cl.Id == catalogItem.Id).First().Quantity
                };

				if (catalogItem.DiscountId.HasValue)
				{
					var discount = _discountService.GetById(catalogItem.DiscountId.Value);
					orderItem.UnitPrice = discount.NewValue;
				}
				else
				{
					orderItem.UnitPrice = catalogItem.Price;
				}

                orderViewModel.ItemsPreview.Items.Add(orderItem);
            }

            return orderViewModel;
        }

        public int AddOrder(OrderViewModel orderViewModel)
        {
            var cartlines = _cartService.Cart.Lines;

            var cartItemIds = cartlines.Select(cl => cl.Id);
            var catalogItems = _catalogService.GetAll()
                .Where(ci => cartItemIds.Any(id => id == ci.Id));

            var order = new Order();
            order.OrderItems = new List<OrderItem>();
            order.CreationDate = DateTime.Now.ToUniversalTime();

            foreach(var line in cartlines)
            {
                var catalogItem = _catalogService.GetById(line.Id);

                var orderItem = new OrderItem()
                {
                    CreationDate = DateTime.Now.ToUniversalTime(),
                    ProductId = catalogItem.Id,
                    Quantity = line.Quantity
                };

				if (catalogItem.DiscountId.HasValue)
				{
					var discount = _discountService.GetById(catalogItem.DiscountId.Value);
					orderItem.UnitPrice = discount.NewValue;
				}
				else
				{
					orderItem.UnitPrice = catalogItem.Price;
				}

				order.OrderItems.Add(orderItem);
            }

            order.Address1 = orderViewModel.Address1;
            order.Address2 = orderViewModel.Address2;
            order.CustomerEmail = orderViewModel.CustomerEmail;
            order.FirstName = orderViewModel.FirstName;
            order.LastName = orderViewModel.LastName;
            order.PhoneNumber = orderViewModel.PhoneNumber;
            order.PhoneNumber2 = orderViewModel.PhoneNumber2;
            order.ZipCode = orderViewModel.ZipCode;
            order.OrderDiscount = _cartService.Cart.Discount;
            order.OrderSubTotal = _cartService.Cart.SubTotal;
            order.OrderTotal = _cartService.Cart.Total;

            _orderService.Insert(order);

            return order.OrderId;
        }

        public void RemoveOrder(int orderId)
        {
            var order = _orderService.GetById(orderId);

            if (order != null)
            {
                _orderService.Delete(order);
            }
        }
    }
}