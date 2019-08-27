using System.Collections.Generic;
using DroneStore.Web.Models;

namespace DroneStore.Web.Services
{
    public interface ICatalogViewModelService
    {
        CatalogViewModel GetCatalogModel();
        CatalogItemViewModel GetById(int itemId);
        CatalogViewModel GetItemsByFilter(CatalogFilterViewModel catalogFilter);
        CatalogViewModel GetItems(int? currentPage, int? itemsPerPage, string currentBrand, SortBy? sortBy);
        IEnumerable<CatalogItemViewModel> GetAllItems { get; }
    }
}
