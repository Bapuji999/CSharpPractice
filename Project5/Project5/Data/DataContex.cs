using Microsoft.EntityFrameworkCore;
using Project5.Models;

namespace Project5.Data
{
    public class DataContex: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRoll> UserRolls { get; set; }
        public DbSet<CustomerIntrest> CustomerIntrests { get; set; }
        public DataContex(DbContextOptions<DataContex> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Vendor)
                .HasForeignKey(p => p.VendorId);
            modelBuilder.Entity<CustomerIntrest>()
                .HasKey(ci => new {ci.CustomerId, ci.ProductId});
            modelBuilder.Entity<CustomerIntrest>()
                .HasOne(ci => ci.Customer)
                .WithMany(u => u.CustomerIntrests)
                .HasForeignKey(ci => ci.CustomerId);
            modelBuilder.Entity<CustomerIntrest>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CustomerIntrests)
                .HasForeignKey(ci => ci.ProductId);
            modelBuilder.Entity<UserRoll>().HasData(
                    new UserRoll { RollId=1, RollType="Admin" },
                    new UserRoll { RollId = 2, RollType = "Vendor" },
                    new UserRoll { RollId = 3, RollType = "Customer" }
               );
            modelBuilder.Entity<User>().HasData(
                    new User { UserId = 1, UserName="Admin1", Email="admin999@gmail.com", Phone="9874563210", Password= "Admin1", RollId=1},
                    new User { UserId = 2, UserName = "vendor1", Email = "vendor999@gmail.com", Phone = "7896543210", Password = "vendor1", RollId = 2 },
                    new User { UserId = 3, UserName = "vendor2", Email = "vendor99@gmail.com", Phone = "6985741237", Password = "vendor2", RollId = 2 },
                    new User { UserId = 4, UserName = "vendor3", Email = "vendor9@gmail.com", Phone = "6985231475", Password = "vendor3", RollId = 2 },
                    new User { UserId = 5, UserName = "Bipin", Email = "bipin@gmail.com", Phone = "7458963215", Password = "customer1", RollId = 3 },
                    new User { UserId = 6, UserName = "Harsha", Email = "harsha@gmail.com", Phone = "8596741235", Password = "customer2", RollId = 3 },
                    new User { UserId = 7, UserName = "Laxman", Email = "laxman@gmail.com", Phone = "9632587451", Password = "customer3", RollId = 3 },
                    new User { UserId = 8, UserName = "Nihar", Email = "nihar@gmail.com", Phone = "8574963214", Password = "customer4", RollId = 3 }
                );
        }
    }
}
