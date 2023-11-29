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
        private IProfileRepositoryDB _data;
        
        public ProfilesController(IProfileRepositoryDB data)
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
                IEnumerable<Profile> profiles = _data.GetProfiles();
                return Ok(profiles);
            } catch (Exception ex)
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
                Profile foundProfile = _data.GetProfileById(id);
                return Ok(foundProfile);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<ProfilesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Post([FromBody] Profile profile)
        {
            try
            {
                Profile NewProfile = _data.AddProfile(profile);
                return Created("A new profile was created: ", profile);
            }catch (Exception ex)
            {
                return NotFound();
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
                Profile? oldProfile = _data.UpdateProfile(id, newValues);
                return Created("Oenskede profil blev opdateret", newValues);
            }
            catch (Exception ex)
            {
                return NotFound();
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
                Profile? profile = _data.DeleteProfile(id);
                return Ok($"profil med id {id} blev slettet");
            } catch (Exception ex)
            {
                return NotFound($"Profil med id {id} blev ikke fundet");
            }

        }
    }
}
