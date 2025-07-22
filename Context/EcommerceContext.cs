using e_commerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Users");
                entity.HasMany(e =>e.Orders).WithOne(e =>e.User).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);

            });
        }

    }
}
