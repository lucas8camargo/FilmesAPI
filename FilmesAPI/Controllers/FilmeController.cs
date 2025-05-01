using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmesAPI.Data;
using FilmesApi.Models;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> Get()
        {
            return await _context.Filmes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> Get(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null) return NotFound();
            return filme;
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Post(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Filme filme)
        {
            if (id != filme.Id) return BadRequest();
            _context.Entry(filme).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null) return NotFound();
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
