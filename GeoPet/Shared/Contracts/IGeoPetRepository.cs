using GeoPetAPI.Models;

namespace GeoPetAPI.Shared.Contracts
{
    public interface IGeoPetRepository
    {
        void AddPeople(People people);
        IEnumerable<People> GetPeoples();
        People? GetPeople(int id);
        bool UpdatePeople(People people);
        bool RemovePeople(int id);

        void AddPet(Pet pet);
        Pet? GetPet(int id);
        IEnumerable<Pet> GetPets();
        bool UpdatePet(Pet pet);
        bool RemovePet(int id);
    }
}
