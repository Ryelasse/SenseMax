using Microsoft.AspNetCore.Mvc;
using SenseMax;
using SenseRepositoryDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenseMaxREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DutiesController : ControllerBase
        {
            private IRepositoryDB<Duty> _data;

            public DutiesController(IRepositoryDB<Duty> data)
            {
                _data = data;
            }

            // GET: api/Duties
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public IActionResult Get()
            {
                try
                {
                    IEnumerable<Duty> duties = _data.GetEntities();
                    return Ok(duties);
                }
                catch (InvalidOperationException ioex)
                {
                    return NoContent();
                }
            }

            // GET: api/Duty
            [HttpGet]
            [Route("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult Get(int id)
            {
                try
                {
                    Duty foundDuty = _data.GetEntityById(id);
                    return Ok(foundDuty);
                }
                catch (KeyNotFoundException knfex)
                {
                    return NotFound();
                }
            }

            // POST: api/Duty
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult Post([FromBody] Duty duty)
            {
                try
                {
                    Duty newduty = _data.AddEntity(duty);
                    return Created("A new profile was created: ", duty);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return BadRequest("Dutynavn opfylder ikke kravene.");
                }
            }

            // PUT: api/Duty/5
            [HttpPut]
            [Route("{id}")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult Put(int id, [FromBody] Duty  newValues)
            {
                try
                {
                    Duty? oldDuty = _data.UpdateEntity(id, newValues);
                    return Created("Oenskede artwork blev opdateret", newValues);
                }
                catch (KeyNotFoundException knfex)
                {
                    return NotFound($"Id {id} blev ikke fundet i databasen.");
                }
            }

            // DELETE: api/Duty/5
            [HttpDelete]
            [Route("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult Delete(int id)
            {
                try
                {
                    Duty? duty = _data.DeleteEntity(id);
                    return Ok($"Duty med id {id} blev slettet");
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound($"Duty med id {id} blev ikke fundet");
                }

            }
        }
    }
}
