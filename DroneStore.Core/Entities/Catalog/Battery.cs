namespace DroneStore.Core.Entities.Catalog
{
    public class Battery
	{
        public int BatteryId { get; set; }
		public string Description { get; set; }
		public int Capacity { get; set; }
        public double Voltage { get; set; }
	}
}