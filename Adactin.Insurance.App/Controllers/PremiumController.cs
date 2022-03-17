using Adactin.Insurance.API.DTO;
using Adactin.Insurance.Core;
using Microsoft.AspNetCore.Mvc;

namespace Adactin.Insurance.API.Controllers
{
    [Route("api/premium")]
    [ApiController]
    public class PremiumController : Controller
    {
        private readonly IPremiumFacade _premiumFacade;
        public PremiumController(IPremiumFacade premiumFacade)
        {
            _premiumFacade = premiumFacade;
        }

        [HttpPost("calculate")]
        public IActionResult CalculatePremium([FromBody] CalculatePremiumRequestDTO request)
        {
            var premium = _premiumFacade.CalculatePremium(request.Age, request.OccupationId, request.DeathSumAssured);
            return Ok(premium);
        }
    }
}
