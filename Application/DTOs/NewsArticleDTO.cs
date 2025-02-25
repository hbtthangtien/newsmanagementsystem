using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class NewsArticleDTO
    {
        public string? NewsArticleId { get; set; }
        public string? NewsTitle { get; set; }

        public string? Headline { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public string? NewsContent { get; set; }

        public string? NewsSource { get; set; }

        public string? Category { get; set; }

        public bool? NewsStatus { get; set; } = false;

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Tags { get; set; }
    }
}
