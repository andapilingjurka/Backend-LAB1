using Microsoft.EntityFrameworkCore;
using pharmacy.Model;
using Pharmacy.Models;

namespace E_PharmacyCrud.Controllers.Models
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {
        }
        public DbSet<Stafi> Stafi { get; set; }

        public DbSet<ProduktKozmetik> ProduktKozmetik { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Kontakti> Kontakti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-U1LK9B3; Database=pharmacy1; Trusted_Connection=True; MultipleActiveResultSets=true;trustServerCertificate=true") ; ;                
        }






    }
}
