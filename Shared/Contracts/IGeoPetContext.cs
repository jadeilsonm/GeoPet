using GeoPetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoPetAPI.Shared.Contracts
{
    public interface IGeoPetContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<CaregiverPeople> Peoples { get; set; }
        public int SaveChanges();
    }
}
