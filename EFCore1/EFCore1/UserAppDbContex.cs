using Microsoft.EntityFrameworkCore;

namespace EFCore1
{
    class UserAppDbContex : DbContext
    {
        public DbSet<fatherandson> fatherandson { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Bapuji@999;database=start1");
        }
    }
}
