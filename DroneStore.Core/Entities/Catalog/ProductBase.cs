namespace DroneStore.Core.Entities.Catalog
{
	public class ProductBase
	{
        public int Id { get; set; }
		public decimal Price { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public string FullDescription { get; set; }
		public int Quantity { get; set; }
		public double FullWeight { get; set; }
        public string Brand { get; set; }
	}
}
