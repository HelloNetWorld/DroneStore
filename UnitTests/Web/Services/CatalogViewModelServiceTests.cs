using System.Linq;
using DroneStore.Core.Entities.Catalog;
using DroneStore.Services.Catalog;
using DroneStore.Web.Models;
using DroneStore.Web.Services;
using Moq;
using Xunit;

namespace UnitTests.Web.Services
{
    public class CatalogViewModelServiceTests
    {
        private readonly Mock<ICatalogService> _catalogService;

        public CatalogViewModelServiceTests()
        {
            _catalogService = new Mock<ICatalogService>();

            _catalogService.Setup(x => x.GetBrands()).Returns(new[] { "DJI", "MJX" });
            _catalogService.Setup(x => x.GetAll()).Returns(
                new[] {
                    new CatalogItem() { Id = 1, ImageId = 3, Name = "DJI Mavic 2 Pro", Price = (decimal)12.34},
                    new CatalogItem() { Id = 2, ImageId = 5, Name = "MJX Bugs 2 SE", Price = (decimal)56.78 },
                    new CatalogItem() { Id = 3, ImageId = 7, Name = "MJX X600", Price = (decimal)99.99 },
                    new CatalogItem() { Id = 4, ImageId = 9, Name = "MJX Bugs 3", Price = (decimal)12.34 }
                });
            _catalogService.Setup(x => x.GetById(1)).Returns(
                new CatalogItem() { Id = 1, ImageId = 3, Name = "DJI Mavic 2 Pro", Price = (decimal)12.34 });
            _catalogService.Setup(x => x.GetById(2)).Returns(
                new CatalogItem() { Id = 2, ImageId = 5, Name = "MJX Bugs 2 SE", Price = (decimal)56.78 });
            _catalogService.Setup(x => x.GetById(3)).Returns(
                new CatalogItem() { Id = 3, ImageId = 7, Name = "MJX X600", Price = (decimal)99.99 });
            _catalogService.Setup(x => x.GetById(4)).Returns(
                new CatalogItem() { Id = 4, ImageId = 9, Name = "MJX Bugs 3", Price = (decimal)12.34 });
        }

        [Fact]
        public void Returns_GetAll()
        {
            var service = new CatalogViewModelService(_catalogService.Object, null);

            var result = service.GetAll();

            Assert.Equal(4, result.CatalogItems.Count());
            Assert.Equal(1, result.CatalogItems.First().Id);
            Assert.Equal(4, result.CatalogItems.Last().Id);
            Assert.Equal(new[] {"All", "DJI", "MJX" }, result.Filter.Filter.FilterByBrand.Brands);
            Assert.Equal("All", result.Filter.Filter.FilterByBrand.CurrentBrand);
            Assert.Equal(SortBy.None, result.Filter.Filter.SortingBy);
            Assert.Equal(4, result.Filter.Pagination.ItemsPerPage);
            Assert.Equal(2, result.Filter.Pagination.NextPage);
            Assert.Equal(0, result.Filter.Pagination.PreviousPage);
            Assert.Equal(4, result.Filter.Pagination.TotalItems);
            Assert.Equal(1, result.Filter.Pagination.TotalPages);
            Assert.Equal(1, result.Filter.Pagination.CurrentPage);
        }

        [Fact]
        public void Returns_GetItems()
        {
            var service = new CatalogViewModelService(_catalogService.Object, null);

            var result = service.GetItems(2, 2, null, SortBy.None);

            Assert.Equal(2, result.CatalogItems.Count());
            Assert.Equal(3, result.CatalogItems.First().Id);
            Assert.Equal(4, result.CatalogItems.Last().Id);
            Assert.Equal(new[] { "All", "DJI", "MJX" }, result.Filter.Filter.FilterByBrand.Brands);
            Assert.Equal("All", result.Filter.Filter.FilterByBrand.CurrentBrand);
            Assert.Equal(SortBy.None, result.Filter.Filter.SortingBy);
            Assert.Equal(2, result.Filter.Pagination.ItemsPerPage);
            Assert.Equal(3, result.Filter.Pagination.NextPage);
            Assert.Equal(1, result.Filter.Pagination.PreviousPage);
            Assert.Equal(4, result.Filter.Pagination.TotalItems);
            Assert.Equal(2, result.Filter.Pagination.TotalPages);
            Assert.Equal(2, result.Filter.Pagination.CurrentPage);
        }

        [Fact]
        public void Returns_GetItems_With_Default_Values()
        {
            var service = new CatalogViewModelService(_catalogService.Object, null);

            var result = service.GetItems(null, null, null, SortBy.None);

            Assert.Equal(4, result.CatalogItems.Count());
            Assert.Equal(1, result.CatalogItems.First().Id);
            Assert.Equal(4, result.CatalogItems.Last().Id);
            Assert.Equal(new[] { "All", "DJI", "MJX" }, result.Filter.Filter.FilterByBrand.Brands);
            Assert.Equal("All", result.Filter.Filter.FilterByBrand.CurrentBrand);
            Assert.Equal(SortBy.None, result.Filter.Filter.SortingBy);
            Assert.Equal(4, result.Filter.Pagination.ItemsPerPage);
            Assert.Equal(2, result.Filter.Pagination.NextPage);
            Assert.Equal(0, result.Filter.Pagination.PreviousPage);
            Assert.Equal(4, result.Filter.Pagination.TotalItems);
            Assert.Equal(1, result.Filter.Pagination.TotalPages);
            Assert.Equal(1, result.Filter.Pagination.CurrentPage);
        }

        [Fact]
        public void Returns_GetItems_With_Illegal_Values()
        {
            var service = new CatalogViewModelService(_catalogService.Object, null);

            var result = service.GetItems(-1, 99, "", (SortBy?)-1);

            Assert.Equal(4, result.CatalogItems.Count());
            Assert.Equal(1, result.CatalogItems.First().Id);
            Assert.Equal(4, result.CatalogItems.Last().Id);
            Assert.Equal(new[] { "All", "DJI", "MJX" }, result.Filter.Filter.FilterByBrand.Brands);
            Assert.Equal("All", result.Filter.Filter.FilterByBrand.CurrentBrand);
            Assert.Equal((SortBy?)-1, result.Filter.Filter.SortingBy);
            Assert.Equal(99, result.Filter.Pagination.ItemsPerPage);
            Assert.Equal(2, result.Filter.Pagination.NextPage);
            Assert.Equal(0, result.Filter.Pagination.PreviousPage);
            Assert.Equal(4, result.Filter.Pagination.TotalItems);
            Assert.Equal(1, result.Filter.Pagination.TotalPages);
            Assert.Equal(1, result.Filter.Pagination.CurrentPage);
        }

        [Fact]
        public void Returns_GetItemsByFilter()
        {
            var service = new CatalogViewModelService(_catalogService.Object, null);
            var filter = new CatalogFilterViewModel()
            {
                Filter = new FilterViewModel
                {
                    FilterByBrand = new FilterByBrandViewModel
                    {
                        Brands = _catalogService.Object.GetBrands(),
                        CurrentBrand = "All"
                    },
                    SortingBy = SortBy.None
                },
                Pagination = new PaginationViewModel
                {
                    CurrentPage = 1,
                    ItemsPerPage = 4,
                    TotalItems = _catalogService.Object.GetAll().Count()
                }
            };

            var result = service.GetItemsByFilter(filter);


            Assert.Equal(4, result.CatalogItems.Count());
            Assert.Equal(1, result.CatalogItems.First().Id);
            Assert.Equal(4, result.CatalogItems.Last().Id);
            Assert.Equal(new[] { "DJI", "MJX" }, result.Filter.Filter.FilterByBrand.Brands);
            Assert.Equal("All", result.Filter.Filter.FilterByBrand.CurrentBrand);
            Assert.Equal(SortBy.None, result.Filter.Filter.SortingBy);
            Assert.Equal(4, result.Filter.Pagination.ItemsPerPage);
            Assert.Equal(2, result.Filter.Pagination.NextPage);
            Assert.Equal(0, result.Filter.Pagination.PreviousPage);
            Assert.Equal(4, result.Filter.Pagination.TotalItems);
            Assert.Equal(1, result.Filter.Pagination.TotalPages);
            Assert.Equal(1, result.Filter.Pagination.CurrentPage);
        }
    }
}
