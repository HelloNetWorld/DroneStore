using System;
using DroneStore.Core.Entities.Media;
using DroneStore.Core.Entities.Discounts;

namespace DroneStore.Core.Entities.Catalog
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

        public DateTime CreatedinUtc { get; set; }

		public int? DiscountId { get; set; }
		public Discount Discount { get; set; }
    }
}