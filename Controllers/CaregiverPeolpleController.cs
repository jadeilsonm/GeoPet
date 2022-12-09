using GeoPetAPI.Models;
using GeoPetAPI.Shared.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaregiverPeolpleController : ControllerBase
    {
        private readonly IGeoPetRepository _repository;

        public CaregiverPeolpleController(IGeoPetRepository repository)
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
