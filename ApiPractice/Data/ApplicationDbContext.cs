using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) :base(dbContextOptions)
        {
            
        }

        public DbSet<VillaModel> Villas {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VillaModel>().HasData(
                new VillaModel()
                {
                    Id = 1,
                    Name = "Jithesh",
                },
            new VillaModel()
            {
                Id = 2,
                Name = "mani"
            });
        }
    }
}
