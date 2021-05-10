using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Data
{
    public class StoreDb : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public StoreDb(DbContextOptions<StoreDb> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(x =>
            {
                x.Property(c => c.Name).IsRequired();
                x.Property(c => c.Description).IsRequired();
            });

            modelBuilder.Entity<Brand>(x =>
            {
                x.Property(b => b.Name).IsRequired();
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.Description).IsRequired();
                x.HasOne(p => p.Category).WithMany()
                                         .HasForeignKey(p => p.CategoryId)
                                         .IsRequired();
                x.HasOne(p => p.Brand).WithMany()
                                      .HasForeignKey(p => p.BrandId)
                                      .IsRequired();
            });
        }

        public DbSet<ThAmCo.Data.Product> Product { get; set; }
    }
}
