using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_4.Models;

namespace Project_4
{
    class Contex : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehicleIssue> VehicleIssue { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;database=Project4;User=root;Password=Bapuji@999;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.31-mariadb"))
                  //.EnableSensitiveDataLogging()
                  //.LogTo(Console.WriteLine, LogLevel.Information)
                  ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<UserType>()
                .HasKey(u => u.UserTypeId);
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.VehicleId);
            modelBuilder.Entity<VehicleType>()
                .HasKey(v => v.VehicleTypeId);
            modelBuilder.Entity<VehicleIssue>()
                .HasKey(v => v.VehicleIssueId);
            modelBuilder.Entity<PaymentDetails>()
                .HasKey(p => p.PaymentId);

            modelBuilder.Entity<User>().Property(u => u.UserId).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserType>().Property(ut => ut.UserTypeId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Vehicle>().Property(v => v.VehicleId).ValueGeneratedOnAdd();
            modelBuilder.Entity<VehicleType>().Property(vt => vt.VehicleTypeId).ValueGeneratedOnAdd();
            modelBuilder.Entity<VehicleIssue>().Property(vi => vi.VehicleIssueId).ValueGeneratedOnAdd();
            modelBuilder.Entity<PaymentDetails>().Property(p => p.PaymentId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.VehicleIssue)
                .WithOne(v => v.vehicle)
                .HasForeignKey(v => v.VehicleId);

            modelBuilder.Entity<User>()
                .HasMany(v => v.VehicleIssue)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        UserId = 1,
                        UserTypeId = 1,
                        IsAdmin = true,
                        Email = "admin1@gmail.com",
                        UserName = "Admin1"
                    }
                );
            modelBuilder.Entity<UserType>().HasData(
                    new UserType
                    {
                        UserTypeId = 1,
                        UserTypeName = "Gold"
                    },
                    new UserType
                    {
                        UserTypeId = 2,
                        UserTypeName = "Silver"
                    },
                    new UserType
                    {
                        UserTypeId = 3,
                        UserTypeName = "Platinum"
                    }
                );

            modelBuilder.Entity<VehicleType>().HasData(
                    new VehicleType
                    {
                        VehicleTypeId = 1,
                        VehicleTypeName = "SUV"
                    },
                    new VehicleType
                    {
                        VehicleTypeId = 2,
                        VehicleTypeName = "Jeep"
                    },
                    new VehicleType
                    {
                        VehicleTypeId = 3,
                        VehicleTypeName = "Van"
                    },
                    new VehicleType
                    {
                        VehicleTypeId = 4,
                        VehicleTypeName = "Wagon"
                    },
                    new VehicleType
                    {
                        VehicleTypeId = 5,
                        VehicleTypeName = "Coupe"
                    }
                );
        }
    }
}
