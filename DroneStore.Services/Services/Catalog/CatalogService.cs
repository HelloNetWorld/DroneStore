using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using DroneStore.Core.Entities.Catalog;
using DroneStore.Core.Entities.Discounts;
using DroneStore.Core.Entities.Media;
using DroneStore.Data;

namespace DroneStore.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly IRepository<CatalogItem> _catalogRep;
        private readonly IRepository<Image> _imageRep;

        public CatalogService(IRepository<CatalogItem> catalogRep,
                              IRepository<Image> imageRep)
        {
            _catalogRep = catalogRep;
            _imageRep = imageRep;
        }

        public IEnumerable<CatalogItem> GetAll() => 
            _catalogRep.EntitiesReadOnly;

        public CatalogItem GetById(int id) =>
            _catalogRep.GetById(id);
        
        public void Delete(CatalogItem catalogItem)
        {
            Guard.Against.Null(catalogItem, nameof(catalogItem));

            _catalogRep.Delete(catalogItem);

            var image = _imageRep.GetById(catalogItem.ImageId);
            if (image != null)
            {
                _imageRep.Delete(image);
            }
        }

        public void Update(CatalogItem catalogItem)
        {
            Guard.Against.Null(catalogItem, nameof(catalogItem));

            _catalogRep.Update(catalogItem);

            var image = _imageRep.GetById(catalogItem.ImageId);
            if (image != null)
            {
                _imageRep.Update(image);
            }
        }

        public void Insert(CatalogItem catalogItem)
        {
            Guard.Against.Null(catalogItem, nameof(catalogItem));

            _catalogRep.Insert(catalogItem);
        }

        public IEnumerable<string> GetBrands() =>
            _catalogRep.EntitiesReadOnly.Select(e => e.Brand).Distinct();

        public CatalogItem FindCatalogItemByDiscountId(int? discountId) =>
            _catalogRep.EntitiesReadOnly.FirstOrDefault(ci => ci.DiscountId == discountId);
    }
}
