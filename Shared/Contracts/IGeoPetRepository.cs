using GeoPetAPI.Models;

namespace GeoPetAPI.Shared.Contracts
{
    public interface IGeoPetRepository
    {
        void AddPeople(CaregiverPeople people);
        IEnumerable<CaregiverPeople> GetPeoples();
        CaregiverPeople? GetPeople(int id);
        void UpdatePeople(CaregiverPeople people);
        void RemovePeople(CaregiverPeople people);
    }
}
