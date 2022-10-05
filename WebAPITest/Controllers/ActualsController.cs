using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;
using WebAPITest.Services.Repository;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualsController : ControllerBase
    {
        private readonly IActualsRepository _actualService;

        private readonly ILogger<ActualsController> _logger;

        public ActualsController(IActualsRepository actualService ,ILogger<ActualsController> logger)
        {
            _actualService = actualService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actuals>>> GetActuals()
        {
            var actuals = await _actualService.GetActuals();
            return Ok(actuals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actuals>> GetActualsById(string id)
        {
            try
            {
                var actuals = await _actualService.GetActualById(id);

                if (actuals == null)
                {
                    return NotFound("The ID is Invalid");
                }

                return Ok(actuals);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
