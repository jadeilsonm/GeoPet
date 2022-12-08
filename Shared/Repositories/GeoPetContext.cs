using GeoPetAPI.Shared.Contracts;
using GeoPetAPI.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeoPetAPI.Shared.Repositories
{
    public class GeoPetContext : DbContext, IGeoPetContext
    {
        public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options)
        {
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<CaregiverPeople> Peoples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"
                Server=127.0.0.1;
                Database=GeoPet;
                User=sa;
                Password=Password12!
            ");
            }
        }
    }
}
