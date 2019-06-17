using DroneStore.Web.Models;

namespace DroneStore.Web.Services
{
    public interface ICatalogViewModelService
    {
        CatalogViewModel GetAll();
        CatalogViewModel GetItemsByFilter(CatalogFilterViewModel catalogFilter);
        CatalogViewModel GetItems(int? currentPage, int? itemsPerPage, string currentBrand, SortBy? sortBy);
    }
}
