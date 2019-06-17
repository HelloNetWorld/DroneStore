namespace DroneStore.Web.Models
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ImageId { get; set; }
		public int? DiscountId { get; set; }
		public bool HasDiscount { get; set; }
		public bool IsNew { get; set; }
    }
}
