using System;

namespace DroneStore.Web.Models
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        public int PreviousPage => CurrentPage - 1;

        public int NextPage => CurrentPage + 1;

        public override string ToString()
        {
            if (TotalItems == 0) return "Total: 0";

            int first = (CurrentPage - 1) * ItemsPerPage + 1;
            int last = CurrentPage * ItemsPerPage;
            return $"Total: {TotalItems}, items: ({first} - {last})";
        }
    }
}
