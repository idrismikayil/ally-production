using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class Slider : BaseEntity
    {
        public string? Link { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
