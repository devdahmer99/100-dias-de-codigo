using Microsoft.EntityFrameworkCore;

namespace _100_dias_de_codigo.ContextApplication;

public class FilmesContext : DbContext
{
    public FilmesContext(DbContextOptions<FilmesContext> options) : base(options) {}
    
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}