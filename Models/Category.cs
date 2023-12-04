namespace ally.Models
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
