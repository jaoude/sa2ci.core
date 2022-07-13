using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Dal.Data.Entities;

namespace Sa2ci.Core.Dal.Data
{
    public class Sa2ciCoreContext : DbContext
    {
        public DbSet<Member> Members { get; set; } = default!;
        public Sa2ciCoreContext(DbContextOptions<Sa2ciCoreContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Member>()
                .ToTable(tableBuilder => tableBuilder.IsTemporal());
        }
    }
}
