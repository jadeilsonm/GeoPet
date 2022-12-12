using GeoPetAPI.Shared.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoPetAPI.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Age { get; set; }
        public Carry Carry { get; set; } = Carry.medium;
        [ForeignKey("PeopleId")]
        public int PeopleId { get; set; }
        [MaxLength(100)]
        public string Breed { get; set; }
    }
}
