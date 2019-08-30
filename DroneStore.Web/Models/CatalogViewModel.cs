using System.Collections.Generic;

namespace DroneStore.Web.Models
{
    public class CatalogViewModel
    {
        public IEnumerable<CatalogItemViewModel> CatalogItems { get; set; }

        public CatalogFilterViewModel Filter { get; set; }
    }

    public class CatalogFilterViewModel
    {
        public PaginationViewModel Pagination { get; set; }

        public FilterViewModel Filter { get; set; }
    }

    public class FilterViewModel
    {
        public FilterByBrandViewModel FilterByBrand { get; set; }

        public SortBy? SortingBy { get; set; }

        public string GetEnumValue(SortBy? sortBy)
        {
            switch (sortBy)
            {
                case SortBy.None:
                case null:
                    return "None";
                case SortBy.PriceFromLowToHigh:
                    return "Price from low to high";
                case SortBy.PriceFromHighToLow:
                    return "Price from high to low";
                case SortBy.NameFromAtoZ:
                    return "From A to Z";
                case SortBy.NameFromZtoA:
                    return "From Z to A";
                case SortBy.ByDate:
                    return "By Date (New First)";
                case SortBy.Discount:
                    return "Discount";
                default:
                    return sortBy.ToString();
            }
        }
    }

    public class FilterByBrandViewModel
    {
        public string CurrentBrand { get; set; }

        public IEnumerable<string> Brands { get; set; }
    }

    public enum SortBy
    {
        None,
        PriceFromLowToHigh,
        PriceFromHighToLow,
        NameFromZtoA,
        NameFromAtoZ,
        ByDate,
        Discount
    }
}
