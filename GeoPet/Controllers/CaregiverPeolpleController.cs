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
    public class CaregiverPeolpleController : ControllerBase
    {
        private readonly IViaCepService _clientCep;
        private readonly IGeoPetRepository _repository;

        public CaregiverPeolpleController(IGeoPetRepository repository, IViaCepService clientCep)
        {
            _repository = repository;
            _clientCep = clientCep;
        }

        [HttpPost]
        public async Task<IActionResult> NewPeople(People people)
        {
            var resultcep = await _clientCep.FindCep(people.Cep);
            if (resultcep == null)
                return NotFound("CEP Invalido");
            _repository.AddPeople(people);
            var token = new TokenGenerator().Generate(people);
            return Ok(token);
        }

        [HttpGet("/generateToken/{id}")]
        public async Task<IActionResult> GenerateToken(int id)
        {
            var people = _repository.GetPeople(id);
            var token = new TokenGenerator().Generate(people);
            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetPeoples()
        {
            var result = _repository.GetPeoples();

            return Ok(JsonConvert.DeserializeObject<IEnumerable<CarregiverPeople>>(Serializer.Serializar(result)));
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetPeople(int id)
        {
            var result = _repository.GetPeople(id);

            return result != null ? Ok(JsonConvert.DeserializeObject<CarregiverPeople>(Serializer.Serializar(result))) : NotFound("People not found");
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdatePeople(People people)
        {
            var result = _repository.UpdatePeople(people);

            return result ? Ok(people) : NotFound("People not found");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeletePeople(int id)
        {
            var result = _repository.RemovePeople(id);

            return result ? Ok("Remuved Ok") : NotFound("People not found");
        }
    }
}
