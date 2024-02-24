using System.ComponentModel.DataAnnotations.Schema;
using WebsiteTinhThanFoundation.Data;

namespace WebsiteTinhThanFoundation.Models
{
    public class BlogArticleComment : EntityBase
    {
        public string? Email { get; set; }
        public string Comment { get; set; }
        public Guid? BlogArticleId { get; set; }
        [ForeignKey(nameof(BlogArticleId))]
        public virtual BlogArticle BlogArticle { get; set; }
    }
}
