using System.ComponentModel.DataAnnotations;

namespace ally.Models
{
    public class SessionToken : BaseEntity
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
