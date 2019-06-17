namespace DroneStore.Core.Entities.Media
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] BinaryFile { get; set; }
        public string ContentType { get; set; }
    }
}
