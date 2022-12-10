using GeoPetAPI.Shared.Contracts;
using GeoPetAPI.Models;
using Microsoft.EntityFrameworkCore;
using GeoPetAPI.Shared.Constants;

namespace GeoPetAPI.Shared.Repositories
{
    public class GeoPetContext : DbContext, IGeoPetContext
    {
        public GeoPetContext() { }
        public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options)  { }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<People> Peoples { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Defaults.CONNECTION_SGRING)
                          .UseLazyLoadingProxies();

        }
    }
}
