using GeoPetAPI.Shared.Enuns;

namespace GeoPetAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Carry Carry { get; set; } = Carry.medium;
        public int CaregiverId { get; set; }
        public string Breed { get; set; }
    }
}
