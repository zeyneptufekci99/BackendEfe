using Microsoft.EntityFrameworkCore;
using Backend.Data.Entities;

namespace Backend.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Basket> Baskets => Set<Basket>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Size> Sizes => Set<Size>();

        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();

        public DbSet<Color> Colors => Set<Color>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(x => x.Basket).WithOne(x => x.User).HasForeignKey<Basket>(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.NoAction);
          
            modelBuilder.Entity<Product>().HasOne(x => x.Gender).WithMany(x => x.Products).HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.NoAction);
           
            modelBuilder.Entity<Product>().HasOne(x => x.ProductType).WithMany(x => x.Products).HasForeignKey(x => x.ProductTypeId).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
