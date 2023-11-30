using Microsoft.AspNetCore.Mvc;
using SenseMax;
using SenseRepositoryDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenseMaxREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private IRepositoryDB<Profile> _data;
        
        public ProfilesController(IRepositoryDB<Profile> data)
        {
            _data = data;
        }

        // GET: api/<ProfilesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Profile> profiles = _data.GetEntities();
                return Ok(profiles);
            } 
            catch (InvalidOperationException ioex)
            {
                return NoContent();
            }
        }


        // GET api/<ProfilesController>/5
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                Profile foundProfile = _data.GetEntityById(id);
                return Ok(foundProfile);
            }
            catch (KeyNotFoundException knfex)
            {
                return NotFound();
            }
        }

        // POST api/<ProfilesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody] Profile profile)
        {
            try
            {
                Profile NewProfile = _data.AddEntity(profile);
                return Created("A new profile was created: ", profile);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest("Profilnavn opfylder ikke kravene.");
            } 
            catch (ArgumentException aex)
            {
                return BadRequest("Kodeordet opfylder ikke kravene.");
            }

        }

        // PUT api/<ProfilesController>/5
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Profile newValues)
        {
            try
            {
                Profile? oldProfile = _data.UpdateEntity(id, newValues);
                return Created("Oenskede profil blev opdateret", newValues);
            }
            catch (KeyNotFoundException knfex)
            {
                return NotFound($"Id {id} blev ikke fundet i databasen.");
            }
        }

        // DELETE api/<ProfilesController>/5
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                Profile? profile = _data.DeleteEntity(id);
                return Ok($"profil med id {id} blev slettet");
            } 
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Profil med id {id} blev ikke fundet");
            }

        }
    }
}
