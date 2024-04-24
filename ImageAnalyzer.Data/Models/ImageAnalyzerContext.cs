using Microsoft.EntityFrameworkCore;



namespace ImageAnalyzer.Models
{
    public class ImageAnalyzerContext : DbContext
    {
        public ImageAnalyzerContext(DbContextOptions<ImageAnalyzerContext> options) :base(options)
        {

        }
        public DbSet<ImageDetails> ImageDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ImageCategoryMapping> ImageCategoryMapping { get; set; }

    }

    

}
