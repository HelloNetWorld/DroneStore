using System;
using System.IO;
using DroneStore.Core.Entities.Catalog;
using DroneStore.Core.Entities.Media;
using DroneStore.Services.Catalog;
using DroneStore.Services.Media;
using DroneStore.Web.Areas.Admin.Models;
using DroneStore.Web.Areas.Admin.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CatalogController : Controller
    {
        public readonly ICatalogService _catalogService;
        public readonly IImageService _imageService;

        public CatalogController(ICatalogService catalogService,
            IImageService imageService)
        {
            _catalogService = catalogService;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var model = _catalogService.GetAll();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _catalogService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CatalogItem item)
        {
            item.CreatedinUtc = DateTime.UtcNow;
            _catalogService.Update(item);
            return RedirectToAction(nameof(Index));
        }

        // Todo: позже реализовать
        public IActionResult Details(int id)
        {
            return View();
        }

        //Get
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateItemViewModel input)
        {
            var validator = new CreateItemValidator();
            var validationResult = validator.Validate(input);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    input.ValidationErrors.Add(error.ToString());
                }

                return View(input);
            }

            var image = new Image();
            if (input.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    input.Image.CopyTo(memoryStream);
                    image.BinaryFile = memoryStream.ToArray();
                }

                image.ContentType = input.Image.ContentType;
                _imageService.Insert(image);
            }

            input.Item.CreatedinUtc = DateTime.UtcNow;
            input.Item.ImageId = image.Id;
            _catalogService.Insert(input.Item);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var item = _catalogService.GetById(id);
            if (item != null)
            {
                _catalogService.Delete(item);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}