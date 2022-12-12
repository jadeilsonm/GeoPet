using GeoPetAPI.Shared.Contracts;
using GeoPetAPI.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace GeoPetAPI.Shared.Repositories
{
    public class GeoPetRepository : IGeoPetRepository
    {
        private readonly IGeoPetContext _context;
        
        public GeoPetRepository(IGeoPetContext context)
        {
            _context = context;
        }

        public void AddPeople(People people)
        {
            _context.Peoples.Add(people);
            _context.SaveChanges();
        }

        public void AddPet(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public IEnumerable<People> GetPeoples()
        {
            return _context.Peoples.ToList();
        }
        public People? GetPeople(int id)
        {
            return _context.Peoples.Find(id);
        }

        public Pet? GetPet(int id)
        {
            return _context.Pets.FirstOrDefault(x => x.PetId == id);
        }
        public bool UpdatePeople(People people)
        {
            _context.Peoples.Update(people);
            return _context.SaveChanges() >= 1;
        }

        public bool RemovePeople(People people)
        {
            var returns = _context.Peoples.Find(people.PeopleId);
            if (returns is not null)
            {
                _context.Peoples.Remove(people);
                return _context.SaveChanges() >= 1;
            }
            return false;
        }
    }
}
