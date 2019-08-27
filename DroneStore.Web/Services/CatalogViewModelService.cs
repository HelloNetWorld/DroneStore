using System;
using System.Collections.Generic;
using System.Linq;
using DroneStore.Core.Entities.Catalog;
using DroneStore.Services.Catalog;
using DroneStore.Web.Extensions;
using DroneStore.Web.Models;

namespace DroneStore.Web.Services
{
    public class CatalogViewModelService : ICatalogViewModelService
    {
        private readonly ICatalogService _catalogService;
        private readonly IDiscountViewModelService _discountViewModelService;

        public CatalogViewModelService(ICatalogService catalogService,
            IDiscountViewModelService discountViewModelService)
        {
            _catalogService = catalogService;
            _discountViewModelService = discountViewModelService;
        }

        public CatalogViewModel GetCatalogModel()
        {
            var catalogFilter = new CatalogFilterViewModel
            {
                Filter = new FilterViewModel
                {
                    FilterByBrand = new FilterByBrandViewModel
                    {
                        Brands = GetBrands(),
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

        public CatalogItemViewModel GetById(int itemId)
        {
            var item = _catalogService.GetById(itemId);

            var catalogItem = CreateCatalogItemVM(item);

            return catalogItem;
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

        public IEnumerable<CatalogItemViewModel> GetAllItems =>
            _catalogService.GetAll()
            .Select(ci => CreateCatalogItemVM(ci));

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
                .Select(ci => CreateCatalogItemVM(ci));

        private int GetTotalItems(FilterViewModel filter) =>
            _catalogService.GetAll().BrandFilter(filter.FilterByBrand.CurrentBrand).Count();

        private CatalogItemViewModel CreateCatalogItemVM(CatalogItem catalogItem) =>
            new CatalogItemViewModel
            {
                Id = catalogItem.Id,
                ImageId = catalogItem.ImageId,
                Name = catalogItem.Name,
                Price = catalogItem.Price,
                HasDiscount = _discountViewModelService.HasDiscount(catalogItem.DiscountId),
                DiscountId = catalogItem.DiscountId,
                IsNew = catalogItem.IsNew()
            };
    }
}
