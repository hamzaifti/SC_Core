using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SC_Common.Model;

namespace SC_DBContext.SeedData
{

    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //seeding companies
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 1,
                CompanyKey = "6486",
                Name = "Sultan Concrete",
            });


            // Seeding roles
            dynamic[] roleData =
            {
                new {Id = "853619ef-752f-48f8-87ca-0af80aa48bbc", Name="Bank"},
                new {Id = "9c970652-13b2-428a-80a0-406d2fc46ce4", Name = "Paver (H.O)"},
                new {Id = "a2af5924-bc31-4efd-9319-0e418c0cfd8b", Name = "Precast (H.O)"},
                new {Id = "829d3673-9429-44b9-9892-fef3122514c7", Name = "Precast (Site)"},
                new {Id = "9aa8a879-cf25-4bd8-81d8-847ee6497e69", Name = "Paver (Site)"},
                new {Id = "8c1fbf13-dd3c-46df-8e6a-6665022f8783", Name = "Precast (SGD Shop)"},
                new {Id = "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9", Name = "Paver (SGD Shop)"},
                new {Id = "36175e83-845e-4ff0-979e-48e8e22155b1", Name = "FSD Shop"}
            };
            foreach (var role in roleData)
            {
                modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Id = role.Id,
                    Name = role.Name,
                    NormalizedName = role.Name.ToUpper()
                });
            }

            //seeding cash summary

            modelBuilder.Entity<CashSummary>().HasData(
                new CashSummary
                {
                    Id = 1,
                    Narration = "H.O",
                    PaverCladCash = 0,
                    PrecastCash = 0,
                    TotalCash = 0,
                },
                new CashSummary
                {
                    Id = 2,
                    Narration = "Factory",
                    PaverCladCash = 0,
                    PrecastCash = 0,
                    TotalCash = 0,
                },
                new CashSummary
                {
                    Id = 3,
                    Narration = "FSD Shop",
                    PaverCladCash = 0,
                    PrecastCash = 0,
                    TotalCash = 0,
                },
                new CashSummary
                {
                    Id = 4,
                    Narration = "SGD Shop",
                    PaverCladCash = 0,
                    PrecastCash = 0,
                    TotalCash = 0,
                },
                new CashSummary
                {
                    Id = 5,
                    Narration = "Bank Balance",
                    TotalCash = 0,
                }
            );
        }
    }
}
