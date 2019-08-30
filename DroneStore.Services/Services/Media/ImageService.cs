using System.Collections.Generic;
using Ardalis.GuardClauses;
using DroneStore.Core.Entities.Media;
using DroneStore.Data;

namespace DroneStore.Services.Media
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> _imageRep;

        public ImageService(IRepository<Image> imageRep) =>
            _imageRep = imageRep;

        public void Delete(Image image)
        {
            Guard.Against.Null(image, nameof(image));

            _imageRep.Delete(image);
        }

        public Image GetById(int imageId) =>
            _imageRep.GetById(imageId);

        public IEnumerable<Image> GetAll()
             => _imageRep.EntitiesReadOnly;

        public void Insert(Image image)
        {
            Guard.Against.Null(image, nameof(image));

            _imageRep.Insert(image);
        }

        public void Update(Image image)
        {
            Guard.Against.Null(image, nameof(image));

            _imageRep.Update(image);
        }
    }
}
