using System.ComponentModel.DataAnnotations.Schema;
using WebsiteTinhThanFoundation.Data;

namespace WebsiteTinhThanFoundation.Models
{
    public class BlogPost
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime DatePost { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser UserPost { get; set; }
        public DateTime DateUpdate { get; set; }
        public string UserUpdateId { get; set; }
        [ForeignKey("UserUpdateId")]
        public ApplicationUser UserUpdate { get; set; }
    }
}
