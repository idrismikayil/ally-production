using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class Cart : BaseEntity
    {
        [Required]
        public string Token { get; set; }
        public Product Item { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
