using Microsoft.EntityFrameworkCore;
using StationeryInventory.Models;

namespace StationeryInventory.Data
{
    public class StationeryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=stationery.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Supplier>().HasKey(s => s.SupplierId);
            modelBuilder.Entity<Supply>().HasKey(s => s.SupplyId);

            modelBuilder.Entity<Supply>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Supply>()
                .HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(s => s.SupplierId);
        }
    }
}
