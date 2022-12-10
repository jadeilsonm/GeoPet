using GeoPetAPI.Models;
using GeoPetAPI.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace GeoPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IGeoPetRepository _repository;
        private JsonSerializerOptions _options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        public PetsController(IGeoPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("newPet")]
        public IActionResult NewPeople(Pet pet)
        {
            _repository.AddPet(pet);
            return Ok(pet);
        }
    }
}
