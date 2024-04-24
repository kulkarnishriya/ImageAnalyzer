using System.ComponentModel.DataAnnotations;

namespace ImageAnalyzer.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}
