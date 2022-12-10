using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GeoPetAPI.Models
{
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cep { get; set; }

        private Collection<Pet> _pets = new Collection<Pet>();
        public virtual Collection<Pet> Pets
        {
            get => _lazyLoader?.Load(this, ref _pets);
            set => _pets = value;
        }

        private readonly ILazyLoader _lazyLoader;
        public People(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

    }
}
