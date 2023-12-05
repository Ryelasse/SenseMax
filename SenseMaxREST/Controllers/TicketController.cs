using Microsoft.AspNetCore.Mvc;
using SenseMax;
using SenseRepositoryDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenseMaxREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // GET: api/<TicketController>
    public class TicketController : ControllerBase
    {
        private IRepositoryDB<Ticket> _data;

        public TicketController(IRepositoryDB<Ticket> data)
        {
            _data = data;
        }

        // GET: api/Artworks
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Ticket> tickets = _data.GetEntities();
                return Ok(tickets);
            }
            catch (InvalidOperationException ioex)
            {
                return NoContent();
            }
        }

        // GET: api/Artworks/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                Ticket foundTicket = _data.GetEntityById(id);
                return Ok(foundTicket);
            }
            catch (KeyNotFoundException knfex)
            {
                return NotFound();
            }
        }

        // POST: api/Artworks
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Ticket ticket)
        {
            try
            {
                Ticket newTicket = _data.AddEntity(ticket);
                return Created("A new ticket was created: ", ticket);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest("Ticket opfylder ikke kravene.");
            }
        }

        // PUT: api/Artworks/5
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Ticket newValues)
        {
            try
            {
                Ticket? oldTicket = _data.UpdateEntity(id, newValues);
                return Created("Oenskede ticket blev opdateret", newValues);
            }
            catch (KeyNotFoundException knfex)
            {
                return NotFound($"Id {id} blev ikke fundet i databasen.");
            }
        }

        // DELETE: api/Artworks/5
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                Ticket? ticket = _data.DeleteEntity(id);
                return Ok($"Ticket med id {id} blev slettet");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Artwork med id {id} blev ikke fundet");
            }

        }
    }
        
}
