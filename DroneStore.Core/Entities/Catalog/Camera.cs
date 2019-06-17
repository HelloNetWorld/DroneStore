namespace DroneStore.Core.Entities.Catalog
{
    public class Camera
	{
        public int CameraId { get; set; }
		public string Description { get; set; }
		public double? MegaPixels { get; set; }
		public bool? IsControllable { get; set; }
	}
}
