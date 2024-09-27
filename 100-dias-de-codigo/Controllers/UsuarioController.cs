using _100_dias_de_codigo.ContextApplication;
using _100_dias_de_codigo.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _100_dias_de_codigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly FilmesContext _filmesContext;

        public UsuarioController(FilmesContext filmesContext)
        {
            _filmesContext = filmesContext;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> BuscaUsuarios()
        {
            var Usuarios = await _filmesContext.Usuarios.FindAsync();

            return StatusCode(200, Usuarios);
        }

        // Busca um usuario em base
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscaUsuario(int id)
        {
            var usuario = await _filmesContext.Usuarios.FindAsync(id);
            return StatusCode(200, usuario);
        }

        // Cria um registro de usuario em base
        [HttpPost]
        public async Task<ActionResult<Usuario>> CriaUsuario(string nome, string email, string password)
        {
            Criptografia cripto = new Criptografia();
            string passwordCripto = cripto.HashPassword(password);

            Usuario user = new Usuario
            {
                Nome = nome,
                Email = email,
                Password = passwordCripto,
            };

            _filmesContext.Add(user);
            await _filmesContext.SaveChangesAsync();
            return StatusCode(201, user);
        }

        // Remove o registro de um usuario da base de dados
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeletarUsuario(int id)
        {
            var usuario = await _filmesContext.Usuarios.FindAsync(id);

            if (usuario != null)
            {
               _filmesContext.Usuarios.Remove(usuario);

            }

            await _filmesContext.SaveChangesAsync();

            return StatusCode(404,"Usuario não encontrado");
        }

    }
}
