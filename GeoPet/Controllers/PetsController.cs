using GeoPetAPI.Models;
using GeoPetAPI.Services;
using GeoPetAPI.Shared.Contracts;
using GeoPetAPI.Shared.Helprs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeoPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IGeoPetRepository _repository;

        public PetsController(IGeoPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize]
        public IActionResult NewPeople(Pet pet)
        {
            _repository.AddPet(pet);
            return Ok(pet);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetPets()
        {
            var pet = _repository.GetPets();
            var p = Serializer.Serializar(pet);
            return Ok(JsonConvert.DeserializeObject<IEnumerable<Pet>>(p));
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetPet(int id)
        {
            var pet = _repository.GetPet(id);
            return pet == null ? NotFound("NotFound") : Ok(JsonConvert.DeserializeObject<Pet>(Serializer.Serializar(pet)));
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdatePet(Pet pet)
        {
            var result = _repository.UpdatePet(pet);
            return result ? Ok(pet) : NotFound("Pet not found");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeletePet(int id)
        {
            var result = _repository.RemovePet(id);
            return result ? Ok("Remuved Ok") : NotFound("Pet not found");
        }

        [HttpGet("qrcode/{id}")]
        [Authorize]
        public IActionResult GetQrCode(int id)
        {
            var pet = _repository.GetPet(id);
            if (pet is null)
                return NotFound("Information Not Found Pet");
            
            var image = QrCodeGenerator.GenerateByteArray(Serializer.Serializar(pet));
            return File(image, "image/jpeg");
        }
    }
}
