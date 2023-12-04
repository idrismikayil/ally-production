using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class UpperCategory : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public List<Category> Categories { get; set; }
    }
}