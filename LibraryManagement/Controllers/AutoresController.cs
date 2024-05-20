using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class AutoresController : Controller
    {
        private readonly LibraryService _libraryService;

        public AutoresController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _libraryService.GetAllAutores());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var autor = await _libraryService.GetAutorById(id);
            if (autor == null) 
                return NotFound();
            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Autor autor)
        {
            await _libraryService.CreateAutor(autor);
            return CreatedAtAction(nameof(Get), new { id = autor.IdAutor }, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Autor autor)
        {
            if (id != autor.IdAutor) 
                return BadRequest();

            await _libraryService.UpdateAutor(autor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libraryService.DeleteAutor(id);
            return NoContent();
        }
    }
}
