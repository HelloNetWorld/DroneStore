namespace DroneStore.Core.Entities.Catalog
{
    public class Multicopter : ProductBase
    {
        public int NumberOfMotors { get; set; }
        public double MaxFlightDistance { get; set; }
        public string Sensors { get; set; }
        public string TypeOfFlightControl { get; set; }
        public string MobileOSSupport { get; set; }
        public double Weight { get; set; }
        public string Dimensions { get; set; }
        public string Equipment { get; set; }

        public int CameraId { get; set; }
        public Camera Camera { get; set; }
        
        public int BatteryId { get; set; }
        public Battery Battery { get; set; }
    }
}
