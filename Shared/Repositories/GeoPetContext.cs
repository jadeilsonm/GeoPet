using GeoPetAPI.Shared.Contracts;
using GeoPetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoPetAPI.Shared.Repositories
{
    public class GeoPetContext : DbContext, IGeoPetContext
    {
        public GeoPetContext() { }
        public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options)  { }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<CaregiverPeople> Peoples { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
