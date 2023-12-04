using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class Banner:BaseEntity
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
