using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeoPetAPI.Models
{
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(8)]
        public string Cep { get; set; }

        private Collection<Pet> _pets = new Collection<Pet>();
        [JsonIgnore]
        public virtual Collection<Pet>? Pets
        {
            get => _lazyLoader?.Load(this, ref _pets);
            set => _pets = value;
        }

        private readonly ILazyLoader _lazyLoader;
        [JsonConstructor]
        public People() { }
        public People(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
    }
}
