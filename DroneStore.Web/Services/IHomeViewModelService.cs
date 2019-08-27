using System.Collections.Generic;
using DroneStore.Web.Models;

namespace DroneStore.Web.Services
{
    public interface IHomeViewModelService
    {
        IEnumerable<CatalogItemViewModel> TopSellingItems { get; }
        IEnumerable<CatalogItemViewModel> NewItems { get; }
        IEnumerable<CatalogItemViewModel> DiscountItems { get; }
    }
}
