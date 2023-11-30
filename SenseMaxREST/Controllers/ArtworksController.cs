using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenseMax;
using SenseRepositoryDB;

namespace SenseMaxREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworksController : ControllerBase
    {
        private IRepositoryDB<Artwork> _data;
        
        public ArtworksController(IRepositoryDB<Artwork> data)
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
                IEnumerable<Artwork> artworks = _data.GetEntities();
                return Ok(artworks);
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
                Artwork foundArtwork = _data.GetEntityById(id);
                return Ok(foundArtwork);
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
        public IActionResult Post([FromBody] Artwork artwork)
        {
            try
            {
                Artwork newArtwork = _data.AddEntity(artwork);
                return Created("A new profile was created: ", artwork);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest("Profilnavn opfylder ikke kravene.");
            } 
        }

        // PUT: api/Artworks/5
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Artwork newValues)
        {
            try
            {
                Artwork? oldArtwork = _data.UpdateEntity(id, newValues);
                return Created("Oenskede artwork blev opdateret", newValues);
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
                Artwork? artwork = _data.DeleteEntity(id);
                return Ok($"Artwork med id {id} blev slettet");
            } 
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Artwork med id {id} blev ikke fundet");
            }

        }
    }
}
