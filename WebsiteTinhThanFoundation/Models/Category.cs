using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTinhThanFoundation.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
