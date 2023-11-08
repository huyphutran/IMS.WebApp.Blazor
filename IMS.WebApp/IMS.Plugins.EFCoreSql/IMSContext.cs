using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCoreSqlServer
{
    

    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions options) : base(options) 
        {
            
        }


        public DbSet<Inventory>? Inventories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductInventory>? ProductInventories { get; set; }
        public DbSet<InventoryTransaction>? InventoryTransactions { get; set; }
        public DbSet<ProductTransaction>? ProductTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInventory>()
                 .HasKey(pi => new { pi.ProductId, pi.InventoryId });
            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Inventory)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.InventoryId);


            //seeding data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory() { InventoryId = 1, IventoryName = " Bike Seat", Quantity = 10, Price = 2 },
                new Inventory() { InventoryId = 2, IventoryName = " Bike Body", Quantity = 10, Price = 15 },
                new Inventory() { InventoryId = 3, IventoryName = " Bike Wheel", Quantity = 20, Price = 8 },
                new Inventory() { InventoryId = 4, IventoryName = " Bike Pedal", Quantity = 20, Price = 1 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 200 },
                new Product() { ProductId = 2, ProductName = "Motor Bike", Quantity = 15, Price = 20000 }
                );
            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory() { ProductId = 1, InventoryId = 1, InventoryQuantity = 1 },
                new ProductInventory() { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 },
                new ProductInventory() { ProductId = 1, InventoryId = 3, InventoryQuantity = 2 },
                new ProductInventory() { ProductId = 1, InventoryId = 4, InventoryQuantity = 2 }
                );
        }
    }
}
