using ImageAnalyzer.Models;

namespace ImageAnalyzer.Services.Interface
{
    public interface IImageAnalyzerService
    {
        public List<Category> ListCategories();
        public List<ImageDetails> ListImages();

        public List<string> GetImageCategoriesByImageId(string imageId);

        public Task<string> UploadImage(IFormFile image);

    }
}

