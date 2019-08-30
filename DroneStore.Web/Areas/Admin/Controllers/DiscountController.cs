using System;
using DroneStore.Core.Entities.Discounts;
using DroneStore.Services.Catalog;
using DroneStore.Services.Services.Discounts;
using DroneStore.Web.Areas.Admin.Models;
using DroneStore.Web.Areas.Admin.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DroneStore.Web.Extensions;

namespace DroneStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly ICatalogService _catalogService;

        public DiscountController(IDiscountService discountService,
            ICatalogService catalogService)
        {
            _discountService = discountService;
            _catalogService = catalogService;
        }

        // GET: Discount
        public IActionResult Index()
        {
            var model = _discountService.GetAll();
            return View(model);
        }

        // GET: Discount/CreateStep1
        public IActionResult CreateStep1()
        {
            var model = _catalogService.GetAll();
            return View(model);
        }

        // GET: Discount/CreateStep2
        public IActionResult CreateStep2(int id)
        {
            var item = _catalogService.GetById(id);
            if (item == null) return RedirectToAction("Error", "Home");

            var model = new DiscountViewModel();
            if (item.DiscountId.HasValue)
            {
                var discount = _discountService.GetById(item.DiscountId.Value);
                model.ExpireDate = discount.ExpireDateInUtc;
                model.NewPrice = discount.NewValue;
                model.OldPrice = discount.OldValue;
            }

            model.ProductName = item.Name;
            model.ProductId = item.Id;
            return View(model);
        }

        // POST: Discount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStep2(DiscountViewModel input)
        {
            var view = this.Validate(input, new DiscountValidator());
            if (view != null) return view;

            var item = _catalogService.GetById(input.ProductId);
            if (item.DiscountId.HasValue)
            {
                var discount = _discountService.GetById(item.DiscountId.Value);
                discount.ExpireDateInUtc = input.ExpireDate;
                discount.NewValue = input.NewPrice;
                discount.OldValue = input.OldPrice;
                discount.StartDateInUtc = DateTime.UtcNow;
                discount.Id = item.Id;

                _discountService.Update(discount);
            }
            else
            {
                var discount = new Discount
                {
                    ExpireDateInUtc = input.ExpireDate,
                    NewValue = input.NewPrice,
                    OldValue = input.OldPrice,
                    StartDateInUtc = DateTime.UtcNow
                };

                _discountService.Insert(discount);
                item.DiscountId = discount.Id;
                _catalogService.Update(item);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Discount/Edit/5
        public IActionResult Edit(int id)
        {
            var discount = _discountService.GetById(id);
            if (discount == null) return RedirectToAction("Error", "Home");

            var item = _catalogService.FindCatalogItemByDiscountId(id);
            var model = new DiscountViewModel
            {
                DiscountId = discount.Id,
                ExpireDate = discount.ExpireDateInUtc,
                NewPrice = discount.NewValue,
                OldPrice = discount.OldValue,
                ProductId = item.Id,
                ProductName = item.Name
            };

            return View(model);
        }

        // POST: Discount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DiscountViewModel input)
        {
            var errorView = this.Validate(input, new DiscountValidator());
            if (errorView != null) return errorView;

            var discount = _discountService.GetById(input.DiscountId);
            if (discount != null)
            {
                discount.ExpireDateInUtc = input.ExpireDate;
                discount.NewValue = input.NewPrice;
                discount.OldValue = input.OldPrice;
                discount.StartDateInUtc = DateTime.UtcNow;
            }

            _discountService.Update(discount);
            return RedirectToAction(nameof(Index));
        }

        // POST: Discount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var discount = _discountService.GetById(id);
            if (discount != null)
            {
                _discountService.Delete(discount);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}