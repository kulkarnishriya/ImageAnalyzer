using Azure.Storage.Blobs;
using ImageAnalyzer.Models;
using ImageAnalyzer.Repository;
using ImageAnalyzer.Services.Interface;

namespace ImageAnalyzer.Services
{
    public class ImageAnalyzerService : IImageAnalyzerService
    {
        private IUnitOfWork<ImageAnalyzerContext> _uow;
        
        public ImageAnalyzerService(IUnitOfWork<ImageAnalyzerContext> unitOfWork)
        {
            _uow = unitOfWork;
        }
        public List<string> GetImageCategoriesByImageId(string imageId)
        {
            try
            {
                var imageCategoryRepo = _uow.GetRepository<ImageCategoryMapping>();
                var categoyRepo = _uow.GetRepository<Category>();
                var categoryList = imageCategoryRepo.Find(x => x.ImageId.ToString() == imageId).ToList()
                                   .Select(y=> y.CategoryId);
                var categories = categoyRepo.Find(x => categoryList.Contains(x.Id)).ToList().Select(y=> y.CategoryName);
                return categories.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Category> ListCategories()
        {
            try
            {
                var categoryRepo = _uow.GetRepository<Category>();
                var categoryList = categoryRepo.GetAll().ToList();
                return categoryList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ImageDetails> ListImages()
        {
            try
            {
                var imageRepo = _uow.GetRepository<ImageDetails>();
                return imageRepo.GetAll().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        void UploadImage(string fileName, Stream? image)
        {
            try
            {
                string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=saimageanalyzer1507;AccountKey=6bdcKcNn10PPyFJxdq/mJozb66aQXQQylvRZh+TKxH76NHy5Gj157TFn6+BD+dzBqMkBLW6vZWLP+ASthHxakA==;EndpointSuffix=core.windows.net";
                BlobServiceClient blobClient = new BlobServiceClient(blobConnectionString);
                var containerClient = blobClient.GetBlobContainerClient("images");
                var response = containerClient.UploadBlob(fileName, image);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task<string> CallCustomVision(Stream image)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Prediction-Key", "61585095c1fd4f4a8a4d46e8b3a8d437");
                StreamContent content = new StreamContent(image);

                using(var response = await client.PostAsync("https://eastus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/72335368-4f9b-40c2-8aba-1af715955fb2/classify/iterations/ImageClassifier-SH/image", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            try
            {
                var stream = image.OpenReadStream();
                UploadImage(image.FileName, stream);
                var response = await CallCustomVision(stream);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
