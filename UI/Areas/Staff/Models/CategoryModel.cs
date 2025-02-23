using Persistences.Entities;

namespace UI.Areas.Staff.Models
{
    public class CategoryModel
    {
        public short? CategoryId { get; set; }

        public string? CategoryName { get; set; } = null!;

        public string? CategoryDesciption { get; set; } = null!;
        public virtual ICollection<NewsArticle>? NewsArticles { get; set; } = new List<NewsArticle>();
        public virtual Category? ParentCategory { get; set; }
        public short? ParentCategoryId { get; set; }
        public bool? IsActive { get; set; }
        
    }
}
