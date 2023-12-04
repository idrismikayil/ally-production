using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Information { get; set; }
        [Required]
        public string MainImage { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
