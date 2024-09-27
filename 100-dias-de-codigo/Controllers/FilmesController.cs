using _100_dias_de_codigo.ContextApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _100_dias_de_codigo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmesController : ControllerBase
    {
        private readonly FilmesContext _filmesContext;

        public FilmesController(FilmesContext context)
        {
            _filmesContext = context;
        }
        
        //List the films
        // GET: FilmesController
        [HttpGet("/GetFilmes")]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
            var filmes = await _filmesContext.Filmes.ToListAsync();
            return StatusCode(200, filmes);
        }

        [HttpPost("/CreateFilme")]
        public async Task<ActionResult<Filme>> CreateFilme(Filme filme)
        {
            _filmesContext.Add(filme);
            await _filmesContext.SaveChangesAsync();

            return StatusCode(201, filme);
        }

        [HttpGet("/GetFilme/{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var data = await _filmesContext.Filmes.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return StatusCode(200, data);
        }

        [HttpDelete("/DeleteFilme/{id}")]
        public async Task<ActionResult<Filme>> DeleteFilme(int id)
        {
            var filmeExistente = await _filmesContext.Filmes.FindAsync(id);

            if (filmeExistente != null)
            {
                _filmesContext.Filmes.Remove(filmeExistente);
            }
            await _filmesContext.SaveChangesAsync();

            return StatusCode(404, "Nenhum filme encontrado!");
        }

    }
