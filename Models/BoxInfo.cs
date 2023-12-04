using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class BoxInfo:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 150)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }

    }
}
