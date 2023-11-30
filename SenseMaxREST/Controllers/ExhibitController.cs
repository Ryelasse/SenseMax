using Microsoft.AspNetCore.Mvc;
using SenseMax;
using SenseRepositoryDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenseMaxREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitController : ControllerBase
    {
        private IRepositoryDB<Exhibit> _data;

        public ExhibitController(IRepositoryDB<Exhibit> data)
        {
            _data = data;
        }


        // GET: api/<ExhibitController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Exhibit> exhibits = _data.GetEntities();
                return Ok(exhibits);
            }
            catch (InvalidOperationException ioex)
            {
                return NoContent();
            }
        }

        // GET api/<ExhibitController>/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                Exhibit foundExhibit = _data.GetEntityById(id);
                return Ok(foundExhibit);
            }
            catch (KeyNotFoundException knfex)
            {
                return NotFound();
            }
        }

        // POST api/<ExhibitController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Exhibit exhibit)
        {
            try
            {
                Exhibit newExhibit = _data.AddEntity(exhibit);
                return Created("En ny udstilling blev oprettet: ", exhibit);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest("Udstillingsnavn opfylder ikke kravene.");
            }
        }

        // PUT api/<ExhibitController>/5
        [HttpPut("{id}")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Exhibit newValues)
        {
            try
            {
                Exhibit? oldExhibit = _data.UpdateEntity(id, newValues);
                return Created("Oenskede udstilling blev opdateret", newValues);
            }
            catch (KeyNotFoundException knfex)
            {
                return NotFound($"Id {id} blev ikke fundet i databasen.");
            }
        }

        // DELETE api/<ExhibitController>/5
        [HttpDelete("{id}")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                Exhibit? exhibit = _data.DeleteEntity(id);
                return Ok($"Udstilling med id {id} blev slettet");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Udstilling med id {id} blev ikke fundet");
            }

        }
    }
}
