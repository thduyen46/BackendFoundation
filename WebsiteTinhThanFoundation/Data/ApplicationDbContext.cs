using WebsiteTinhThanFoundation.Helpers;
using WebsiteTinhThanFoundation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebsiteTinhThanFoundation.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Registeredvolunteers>? Registeredvolunteers { get; set; } = null!;
        public DbSet<BlogArticle> BlogArticles { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<BlogArticleTag> BlogArticleTags { get; set; } = null!;
        public DbSet<BlogArticleComment> BlogArticleComments { get; set; } = null!;

        public readonly string AdminRoleId = Guid.NewGuid().ToString();
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole() { Id = AdminRoleId, Name = Constants.Roles.Admin, NormalizedName = Constants.Roles.Admin, ConcurrencyStamp = null }
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
            modelBuilder.Entity<BlogArticleTag>()
            .HasKey(m => new { m.BlogArticleId, m.TagId });

            modelBuilder.Entity<BlogArticle>()
            .HasIndex(m => new { m.Permalink })
            .IsUnique(true);


            modelBuilder.Entity<Tag>()
            .HasIndex(m => new { m.Name })
            .IsUnique(true);
        }
    }
}
