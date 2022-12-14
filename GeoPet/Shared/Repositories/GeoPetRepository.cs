using GeoPetAPI.Shared.Contracts;
using GeoPetAPI.Models;
using GeoPetAPI.Shared.Helprs;

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

        public IEnumerable<People> GetPeoples()
        {
            return _context.Peoples.ToList();
        }
        public People? GetPeople(int id)
        {
            return _context.Peoples.Find(id);
        }

        public bool UpdatePeople(People people)
        {
            _context.Peoples.Update(people);
            return _context.SaveChanges() >= 1;
        }

        public bool RemovePeople(int id)
        {
            var returns = _context.Peoples.Find(id);
            if (returns is not null)
            {
                _context.Peoples.Remove(returns);
                return _context.SaveChanges() >= 1;
            }
            return false;
        }

        public void AddPet(Pet pet)
        {
            pet.HashInformation = CreateHashInformation.CreatHash(Serializer.Serializar(pet));
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }
        public Pet? GetPet(int id)
        {
            var pet = _context.Pets.FirstOrDefault(x => x.PetId == id);
            return pet;
        }

        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.ToList();
        }

        public bool UpdatePet(Pet pet)
        {
            pet.HashInformation = CreateHashInformation.CreatHash(Serializer.Serializar(pet));
            _context.Pets.Update(pet);
            return _context.SaveChanges() >= 1;
        }

        public bool RemovePet(int id)
        {
            var returns = _context.Pets.Find(id);
            if (returns is not null)
            {
                _context.Pets.Remove(returns);
                return _context.SaveChanges() >= 1;
            }
            return false;
        }
    }
}
