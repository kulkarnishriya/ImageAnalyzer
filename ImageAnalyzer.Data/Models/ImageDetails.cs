using System.ComponentModel.DataAnnotations;

namespace ImageAnalyzer.Models
{
    public class ImageDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string Path { get; set; }

        public string FileName { get; set; }
    }
}
