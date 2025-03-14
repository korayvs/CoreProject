using Microsoft.EntityFrameworkCore;

namespace CoreProject.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-F1A12T8\\KORAY; database=BirimPerDB; integrated security=true; TrustServerCertificate = True");
        }

        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
