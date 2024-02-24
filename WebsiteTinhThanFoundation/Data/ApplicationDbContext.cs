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

        public DbSet<Registeredvolunteers>? Registeredvolunteers { get; set; }

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
        }
    }
}
