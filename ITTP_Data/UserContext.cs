using ITTP_Domain;
using Microsoft.EntityFrameworkCore;

namespace ITTP_Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Login })
                .IsUnique(true);
        }
    }
}
