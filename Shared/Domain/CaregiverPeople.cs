namespace GeoPetAPI.Shared.Domain
{
    public class CaregiverPeople
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? CEP { get; set; }
        public string? Password { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
