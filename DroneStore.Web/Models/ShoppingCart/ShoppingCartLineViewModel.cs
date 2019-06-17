namespace DroneStore.Web.Models.ShoppingCart
{
    public class ShoppingCartLineViewModel
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
		public decimal DiscountValue { get; set; }
    }
}
