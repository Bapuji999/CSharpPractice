using Microsoft.EntityFrameworkCore;

namespace EFCore2
{
    class DataContex : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;database=UserInfo;User=root;Password=Bapuji@999;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.31-mariadb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(a => a.Accounts)
                .WithOne(b => b.User)
                .HasForeignKey(c => c.UserId);
            //modelBuilder.Entity<User>().HasData(
            //new User { UserId = 1, Name = "User 1", Email = "emai1@gmail.com", Password = "qa@123" },
            //new User { UserId = 2, Name = "User 2", Email = "emai2@gmail.com", Password = "qa@123" }
            //);
        }
    }
}
