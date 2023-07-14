using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Final.Entities
{
	public class AppDbContext : DbContext
	{
		public DbSet<Products> Products { get; set; }
		public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }
        public DbSet<ProductDetaiPropertyDetails> ProductDetaiPropertyDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=Web_QLBH;User ID=SA;Password=Hoangduc96;TrustServerCertificate=True; MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDetaiPropertyDetails>(pdpd =>
            {
                pdpd.HasKey(x => new { x.productID, x.productDetailID, x.propertyDetailID });
                pdpd.HasOne(x=>x.Products).WithMany(y=>y.ProductDetaiPropertyDetails).HasForeignKey(x=>x.productID).OnDelete(DeleteBehavior.ClientSetNull);
                pdpd.HasOne(x=>x.PropertyDetails).WithMany(y=>y.ProductDetaiPropertyDetails).HasForeignKey(x=>x.propertyDetailID).OnDelete(DeleteBehavior.ClientSetNull);
                pdpd.HasOne(x=>x.ProductDetails).WithMany(y=>y.ProductDetaiPropertyDetails).HasForeignKey(x=>x.productDetailID).OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}

