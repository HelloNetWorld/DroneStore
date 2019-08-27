using System.Collections.Generic;
using DroneStore.Core.Entities.Catalog;

namespace DroneStore.Services.Catalog
{
    public interface ICatalogService
    {
        IEnumerable<CatalogItem> GetAll();
        CatalogItem GetById(int id);
        void Delete(CatalogItem catalogItem);
        void Update(CatalogItem catalogItem);
        void Insert(CatalogItem catalogItem);
        IEnumerable<string> GetBrands();
        CatalogItem FindCatalogItemByDiscountId(int? discountId);
    }
}
