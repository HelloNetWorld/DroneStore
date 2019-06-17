using System.Collections.Generic;
using System.Linq;
using DroneStore.Core.Entities.Catalog;
using DroneStore.Web.Models;

namespace DroneStore.Web.Extensions
{
    public static class CatalogExtensions
    {
        public static IEnumerable<CatalogItem> SortByFilter(this IEnumerable<CatalogItem> source, SortBy? sortBy)
        {
            switch (sortBy)
            {
                case SortBy.None:
                case null:
                    return source.OrderBy(i => i.Id);
                case SortBy.NameFromAtoZ:
                    return source.OrderBy(i => i.Name);
                case SortBy.NameFromZtoA:
                    return source.OrderByDescending(i => i.Name);
                case SortBy.PriceFromLowToHigh:
                    return source.OrderBy(i => i.Price);
                case SortBy.PriceFromHighToLow:
                    return source.OrderByDescending(i => i.Price);
                case SortBy.ByDate:
                    return source.OrderByDescending(i => i.CreatedinUtc);
                default: return source.OrderBy(i => i.Id);
            }
        }

        public static IEnumerable<CatalogItem> PageFilter(this IEnumerable<CatalogItem> source, PaginationViewModel pagination)
        {
            if (pagination.CurrentPage < 1 || pagination.CurrentPage > pagination.TotalPages)
            {
                pagination.CurrentPage = 1;
            }

            if (pagination.ItemsPerPage < 1)
            {
                pagination.ItemsPerPage = 4;
            }

            return source.Skip((pagination.CurrentPage - 1) * pagination.ItemsPerPage)
                .Take(pagination.ItemsPerPage);
        }

        public static IEnumerable<CatalogItem> BrandFilter(this IEnumerable<CatalogItem> source, string brand)
        {
            if (brand == "All")
            {
                return source;
            }

            return source.Where(ci => ci.Brand == brand);
        }
    }
}
