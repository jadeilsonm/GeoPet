using GeoPetAPI.Shared.Contracts;
using GeoPetAPI.Shared.Domain;

namespace GeoPetAPI.Shared.Repositories
{
    public class GeoPetRepository : IGeoPetRepository
    {
        private readonly GeoPetContext _context;

        public GeoPetRepository(GeoPetContext context)
        {
            _context = context;
        }

        public void AddPeople(CaregiverPeople people)
        {
            _context.Peoples.Add(people);
            _context.SaveChanges();
        }

        public IEnumerable<CaregiverPeople> GetPeoples()
        {
            return _context.Peoples.ToList();
        }
        public CaregiverPeople? GetPeople(int id)
        {
            return _context.Peoples.Find(id);
        }

        public void UpdatePeople(CaregiverPeople people)
        {
            _context.Peoples.Update(people);
            _context.SaveChanges();
        }

        public void RemovePeople(CaregiverPeople people)
        {
            var returns = _context.Peoples.Find(people.Id);
            if (returns is not null)
            {
                _context.Peoples.Remove(people);
                _context.SaveChanges();
            }
        }
    }
}
