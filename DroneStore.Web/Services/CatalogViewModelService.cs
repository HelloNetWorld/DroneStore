using System;
using System.Collections.Generic;
using System.Linq;
using DroneStore.Services.Catalog;
using DroneStore.Services.Services.Discounts;
using DroneStore.Web.Extensions;
using DroneStore.Web.Models;

namespace DroneStore.Web.Services
{
    public class CatalogViewModelService : ICatalogViewModelService
    {
        private readonly ICatalogService _catalogService;
		private readonly IDiscountService _discountService;

        public CatalogViewModelService(ICatalogService catalogService,
			IDiscountService discountService)
        {
            _catalogService = catalogService;
			_discountService = discountService;
        }

        public CatalogViewModel GetAll()
        {
            var catalogFilter = new CatalogFilterViewModel
            {
                Filter = new FilterViewModel
                {
                    FilterByBrand = new FilterByBrandViewModel
                    {
                        Brands =  GetBrands(),
                        CurrentBrand = "All"
                    },
                    SortingBy = SortBy.None
                },
                Pagination = new PaginationViewModel
                {
                    CurrentPage = 1,
                    ItemsPerPage = 4,
                    TotalItems = _catalogService.GetAll().Count()
                }
            };
            var catalogItems = GetCatalogItems(catalogFilter);

            var viewmodel = new CatalogViewModel
            {
                CatalogItems = catalogItems,
                Filter = catalogFilter
            };

            return viewmodel;
        }

        public CatalogViewModel GetItems(int? currentPage, int? itemsPerPage, string currentBrand, SortBy? sortBy)
        {
            var filter = new FilterViewModel
            {
                FilterByBrand = new FilterByBrandViewModel
                {
                    Brands = GetBrands(),
                    CurrentBrand = GetBrands().Contains(currentBrand) ? currentBrand : "All"
                },
                SortingBy = sortBy
            };

            var catalogFilter = new CatalogFilterViewModel
            {
                Filter = filter,
                Pagination = new PaginationViewModel
                {
                    CurrentPage = currentPage ?? 1,
                    ItemsPerPage = itemsPerPage ?? 4,
                    TotalItems = GetTotalItems(filter)
                }
            };

            var catalogItems = GetCatalogItems(catalogFilter);

            var viewmodel = new CatalogViewModel
            {
                CatalogItems = catalogItems,
                Filter = catalogFilter
            };

            return viewmodel;
        }

        public CatalogViewModel GetItemsByFilter(CatalogFilterViewModel catalogFilter)
        {
            var viewmodel = new CatalogViewModel
            {
                CatalogItems = GetCatalogItems(catalogFilter),
                Filter = catalogFilter
            };

            return viewmodel;
        }

        private IEnumerable<string> GetBrands()
        {
            var brands = new List<string> { "All" };
            brands.AddRange(_catalogService.GetBrands());            
            return brands;
        }

        private IEnumerable<CatalogItemViewModel> GetCatalogItems(CatalogFilterViewModel catalogFilter)
            => _catalogService.GetAll()
                .BrandFilter(catalogFilter.Filter.FilterByBrand.CurrentBrand)
                .SortByFilter(catalogFilter.Filter.SortingBy)
                .PageFilter(catalogFilter.Pagination)
                .Select(ci => new CatalogItemViewModel
                {
                    Id = ci.Id,
                    ImageId = ci.ImageId,
                    Name = ci.Name,
                    Price = ci.Price,
					HasDiscount = HasDiscount(ci.DiscountId),
					DiscountId = ci.DiscountId
                });

        private int GetTotalItems(FilterViewModel filter) =>
            _catalogService.GetAll().BrandFilter(filter.FilterByBrand.CurrentBrand).Count();

		private bool HasDiscount(int? discountId)
		{
			if (!discountId.HasValue) return false;
			var discount = _discountService.GetById(discountId.Value);

			if (discount == null) return false;

			return DateTime.Compare(
				discount.ExpireDateInUtc, DateTime.Now.ToUniversalTime()) > 0;
		}
	}
}
