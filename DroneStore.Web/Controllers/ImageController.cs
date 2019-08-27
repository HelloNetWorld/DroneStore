using DroneStore.Services.Media;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheFile = System.IO.File;

namespace DroneStore.Web.Controllers
{
    [AllowAnonymous]
	public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService) => 
            _imageService = imageService;

        public IActionResult Process(int imageId)
        {
            var imageToProcess = _imageService.GetById(imageId);

            if (imageToProcess == null)
            {
                string fileName = "~/icons/no-product-image.png";
                string contentType = "image/png";

                var bytes = TheFile.ReadAllBytes(fileName);
                return new FileContentResult(bytes, contentType);
            }

            return new FileContentResult(imageToProcess.BinaryFile, imageToProcess.ContentType);
        }
    }
}