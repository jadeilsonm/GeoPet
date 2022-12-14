using GeoPetAPI.Models;

namespace GeoPetAPI.Shared.Contracts
{
    public class CarregiverPeople
    {
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cep { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
