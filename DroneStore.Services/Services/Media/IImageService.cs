using System.Collections.Generic;
using DroneStore.Core.Entities.Media;

namespace DroneStore.Services.Media
{
    public interface IImageService
    {
        IEnumerable<Image> GetAll();
        void Delete(Image image);
        void Update(Image image);
        void Insert(Image image);
        Image GetById(int imageId);
    }
}
