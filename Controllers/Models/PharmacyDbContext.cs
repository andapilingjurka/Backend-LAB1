using Microsoft.EntityFrameworkCore;

namespace E_PharmacyCrud.Controllers.Models
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {
        }
        public DbSet<Stafi> Stafi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DUKAGJIN\\MSSQLSERVER1; Database=stafi; Trusted_Connection=True; MultipleActiveResultSets=true;trustServerCertificate=true") ; ;                
        }






    }
}
