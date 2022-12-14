using GeoPetAPI.Models;
using System.Diagnostics.CodeAnalysis;

namespace GeoPetAPI.Shared.Contracts
{
    // Não tem Logica de negocio 
    [ExcludeFromCodeCoverage]
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
