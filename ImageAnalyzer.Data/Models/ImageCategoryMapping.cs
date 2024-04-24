using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageAnalyzer.Models
{
    public class ImageCategoryMapping
    {
        [Key]
        public Guid ImageCategoryId { get; set; }
        [ForeignKey ("ImageDetails")]
        public Guid ImageId { get; set; }
        [ForeignKey ("Category")]
        public Guid CategoryId { get; set; }
    }
}
