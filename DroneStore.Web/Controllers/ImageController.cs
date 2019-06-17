using DroneStore.Services.Media;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Controllers
{
	[AllowAnonymous]
	public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Process(int imageId)
        {
            var imageToProcess = _imageService.GetById(imageId);

            if (imageToProcess == null) return NoContent();

            return new FileContentResult(imageToProcess.BinaryFile, imageToProcess.ContentType);
        }
    }
}