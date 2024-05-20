using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LibrosController : ControllerBase
    {
        private readonly LibraryService _libraryService;

        public LibrosController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _libraryService.GetAllLibros());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var libro = await _libraryService.GetLibroById(id);
            if (libro == null)
                return NotFound();
            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Libro libro)
        {
            await _libraryService.CreateLibro(libro);
            return CreatedAtAction(nameof(Get), new { id = libro.IdLibro }, libro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.IdLibro)
                return BadRequest();

            await _libraryService.UpdateLibro(libro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libraryService.DeleteLibro(id);
            return NoContent();
        }
    }
}
