using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Dal.Data.Entities;

namespace Sa2ci.Core.Dal.Data
{
    public class Sa2ciCoreContext : DbContext
    {
        public DbSet<Member> Members { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; } = default!;
        public Sa2ciCoreContext(DbContextOptions<Sa2ciCoreContext> options)
           : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Pre-convention model configuration goes here
            configurationBuilder
                .Properties<string>()
                .AreUnicode(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable(tableBuilder => tableBuilder.IsTemporal());
            modelBuilder.Entity<UserRole>().ToTable(tableBuilder => tableBuilder.IsTemporal());
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserID, x.RoleID });
        }
    }
}
