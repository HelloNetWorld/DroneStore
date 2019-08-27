using System.Collections.Generic;
using System.Linq;
using DroneStore.Services.Catalog;
using DroneStore.Services.Services.Orders;
using DroneStore.Web.Models;
using MoreLinq;

namespace DroneStore.Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly ICatalogService _catalogService;
        private readonly ICatalogViewModelService _catalogViewModelService;
        private readonly IOrderItemService _orderItemService;
        private readonly IDiscountViewModelService _discountViewModelService;

        public HomeViewModelService(ICatalogService catalogService,
            IOrderItemService orderItemService,
            IDiscountViewModelService discountViewModelService,
            ICatalogViewModelService catalogViewModelService)
        {
            _catalogService = catalogService;
            _orderItemService = orderItemService;
            _catalogViewModelService = catalogViewModelService;
            _discountViewModelService = discountViewModelService;
        }

        public IEnumerable<CatalogItemViewModel> DiscountItems =>
            _catalogViewModelService.GetAllItems
                .Where(ci => _discountViewModelService.HasDiscount(ci.DiscountId))
                .Shuffle()
                .Take(10);

        public IEnumerable<CatalogItemViewModel> NewItems =>
            _catalogViewModelService.GetAllItems
                .Where(ci => ci.IsNew)
                .Shuffle()
                .Take(10);

        public IEnumerable<CatalogItemViewModel> TopSellingItems
        {
            get
            {
                var groupedProductIds = _orderItemService.GetAll()
                    .GroupBy(o => o.ProductId)
                    .OrderByDescending(p => p.Sum(oi => oi.Quantity))
                    .Take(10);

                foreach (var @group in groupedProductIds)
                {
                    yield return _catalogViewModelService.GetById(@group.Key);
                }
            }
        }
    }
}