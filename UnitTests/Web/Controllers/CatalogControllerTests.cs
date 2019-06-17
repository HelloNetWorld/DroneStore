using System.Collections.Generic;
using System.Linq;
using DroneStore.Core.Entities.Media;
using DroneStore.Services.Media;
using DroneStore.Web.Controllers;
using DroneStore.Web.Models;
using DroneStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTests.Web.Controllers
{
    public class CatalogControllerTests
    {
        //private readonly Mock<IImageService> _imageService;
        //private readonly Mock<ICatalogViewModelService> _catalogService;

        //public CatalogControllerTests()
        //{
        //    _imageService = new Mock<IImageService>();
        //    _catalogService = new Mock<ICatalogViewModelService>();
        //}

        //[Fact]
        //public void Returns_ProcessedImage()
        //{
        //    _imageService.Setup(x => x.GetById(14)).Returns(
        //        new Image { ImageId = 14, BinaryFile = new byte[] { 0x20, 0x21, 0x22 }, ContentType = "image/jpeg" });
        //    var controller = new CatalogController(_imageService.Object, null);

        //    var result = controller.ProcessImage(14) as FileContentResult;

        //    Assert.Equal("image/jpeg", result.ContentType);
        //    Assert.Equal(new byte[] { 0x20, 0x21, 0x22 }, result.FileContents);
        //}

        //[Fact]
        //public void Returns_NoContent_ProcessedImage()
        //{
        //    _imageService.Setup(foo => foo.GetById(14)).Returns((Image) null);
        //    var controller = new CatalogController(_imageService.Object, null);

        //    var result = controller.ProcessImage(14) as NoContentResult;

        //    Assert.Equal(204, result.StatusCode);
        //}


        //private CatalogViewModel Catalog =>
        //    new CatalogViewModel
        //    {
        //        CatalogItems = new []
        //        {
        //            new CatalogItemViewModel { Id = 1, ImageId = 3, Name = "DJI Mavic 2 Pro", Price = (decimal)12.34 },
        //            new CatalogItemViewModel { Id = 2, ImageId = 5, Name = "MJX Bugs 2 SE", Price = (decimal)56.78 },
        //            new CatalogItemViewModel { Id = 3, ImageId = 7, Name = "MJX X600", Price = (decimal)99.99 },
        //            new CatalogItemViewModel { Id = 4, ImageId = 9, Name = "MJX Bugs 3", Price = (decimal)12.34 }
        //        },
        //        Filter = new CatalogFilterViewModel
        //        {
        //            Filter = new FilterViewModel
        //            {
        //                FilterByBrand = new FilterByBrandViewModel
        //                {
        //                    Brands = new List<string> { "DJI", "MJX" },
        //                    CurrentBrand = "DJI"
        //                },
        //                SortingBy = SortBy.ByDate
        //            },
        //            Pagination = new PaginationViewModel
        //            {
        //                CurrentPage = 1,
        //                ItemsPerPage = 4,
        //                TotalItems = 4
        //            }
        //        }
        //    };

        //[Fact]
        //public void Returns_Index()
        //{
        //    _catalogService.Setup(foo => foo.GetAll()).Returns(Catalog);
        //    var controller = new CatalogController(null, _catalogService.Object);

        //    var result = controller.Index() as ViewResult;

        //    var model = result.Model as CatalogViewModel;

        //    Assert.Equal(4, model.CatalogItems.Count());
        //    Assert.Equal(Catalog.CatalogItems.First().Id, model.CatalogItems.First().Id);
        //    Assert.Equal(Catalog.CatalogItems.Last().Id, model.CatalogItems.Last().Id);

        //    Assert.Equal(Catalog.Filter.Filter.FilterByBrand.CurrentBrand,
        //        model.Filter.Filter.FilterByBrand.CurrentBrand);
        //    Assert.Equal(Catalog.Filter.Filter.SortingBy,
        //        model.Filter.Filter.SortingBy);
        //    Assert.Equal(Catalog.Filter.Pagination.ItemsPerPage,
        //        model.Filter.Pagination.ItemsPerPage);
        //    Assert.Equal(Catalog.Filter.Pagination.NextPage,
        //        model.Filter.Pagination.NextPage);
        //    Assert.Equal(Catalog.Filter.Pagination.PreviousPage,
        //        model.Filter.Pagination.PreviousPage);
        //    Assert.Equal(Catalog.Filter.Pagination.TotalItems,
        //        model.Filter.Pagination.TotalItems);
        //    Assert.Equal(Catalog.Filter.Pagination.TotalPages,
        //        model.Filter.Pagination.TotalPages);
        //}
    }
}
