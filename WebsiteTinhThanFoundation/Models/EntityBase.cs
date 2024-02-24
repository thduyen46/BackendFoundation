using System.ComponentModel.DataAnnotations;

namespace WebsiteTinhThanFoundation.Models
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
