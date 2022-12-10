using GeoPetAPI.Models;

namespace GeoPetAPI.Shared.Contracts
{
    public interface IGeoPetRepository
    {
        void AddPeople(People people);
        IEnumerable<People> GetPeoples();
        People? GetPeople(int id);
        bool UpdatePeople(People people);
        bool RemovePeople(People people);

        void AddPet(Pet pet);
    }
}
