using GeoPetAPI.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GeoPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominationController : ControllerBase
    {
        private readonly INominatinService _nominatinService;

        public NominationController(INominatinService nominatinService)
        {
            _nominatinService = nominatinService;
        }
        [HttpGet("{lat}/{lon}")]
        public async Task<IActionResult> Get(string lat, string lon)
        {
            var result = await _nominatinService.GetInfomatioByLatAndLon(lat, lon);
            return Ok(result);
        }
    }
}
