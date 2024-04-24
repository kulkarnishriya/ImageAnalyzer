using ImageAnalyzer.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ImageAnalyzer.Controllers
{
   
    [ApiController]
    [Route("v1/api/imageanalysis")]
    public class ImageAnalyzerController : ControllerBase
    {
        private IImageAnalyzerService _imageAnalyzerService;

        public ImageAnalyzerController(IImageAnalyzerService imageAnalyzerService)
        {
            _imageAnalyzerService = imageAnalyzerService;
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_imageAnalyzerService.ListCategories());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetImages")]
        public IActionResult GetImages()
        {
            try
            {
                return Ok(_imageAnalyzerService.ListImages());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("CategoryByImage")]
        public IActionResult CategoryByImageId(string imageId)
        {
            try
            {
                return Ok(_imageAnalyzerService.GetImageCategoriesByImageId(imageId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            try
            {
                return Ok(await _imageAnalyzerService.UploadImage(image));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

        