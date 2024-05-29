using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SC_Common.Model;
using SC_DBContext.SeedData;
using System.Security.Cryptography.X509Certificates;

namespace SC_DBContext
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<IouReference> IouReferences { get; set; }
        public DbSet<CashSummary> CashSummaries { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
