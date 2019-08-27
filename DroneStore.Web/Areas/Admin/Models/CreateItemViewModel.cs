using System.Collections.Generic;
using DroneStore.Core.Entities.Catalog;
using Microsoft.AspNetCore.Http;

namespace DroneStore.Web.Areas.Admin.Models
{
    public class CreateItemViewModel
    {
        public CatalogItem Item { get; set; }
        public IFormFile Image { get; set; }

        public ICollection<string> ValidationErrors { get; set; } = new List<string>();
    }
}
