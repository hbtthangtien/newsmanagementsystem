using Persistences.Entities;

namespace UI.Areas.Staff.Models
{
    public class NewsArticleModel
    {
        public string NewsArticleId { get; set; }
        public string? NewsTitle { get; set; }

        public string? Headline { get; set; } 

        public DateTime? CreatedDate { get; set; }

        public string? NewsContent { get; set; }

        public string? NewsSource { get; set; }

        public string? Category { get; set; }

        public bool? NewsStatus { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public string? Tags { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
