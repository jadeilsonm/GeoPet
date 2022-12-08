using GeoPetAPI.Shared.Domain;
using GeoPetAPI.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaregiverPeolpleController : ControllerBase
    {
        private readonly GeoPetRepository _repository;

        public CaregiverPeolpleController(GeoPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("createLogin")]
        public IActionResult NewPeople([FromBody] CaregiverPeople people)
        {
            _repository.AddPeople(people);
            return CreatedAtAction("created new People", people);
        }
    }
}
