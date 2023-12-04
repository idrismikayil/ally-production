using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class AboutUs:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
