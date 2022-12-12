using GeoPetAPI.Models;
using GeoPetAPI.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using GeoPetAPI.Services;
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

        [HttpGet("/{id}")]
        public IActionResult GetPet(int id)
        {
            var pet = _repository.GetPet(id);
            return pet == null ? NotFound("NotFound") : Ok(pet);
        }

        [HttpGet("qrcode/{id}")]
        public IActionResult GetQrCode(int id)
        {
            var pet = _repository.GetPet(id);
            if (pet is null)
                return NotFound("Information Not Found Pet");
            var image = QrCodeGenerator.GenerateByteArray(JsonSerializer.Serialize(pet, _options));
            return File(image, "image/jpeg");
        }
    }
}
