namespace ally.Models
{
    public class SubCategory : BaseEntity
    {
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}