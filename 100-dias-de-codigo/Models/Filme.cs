using System.ComponentModel.DataAnnotations;

namespace _100_dias_de_codigo;

public class Filme
{
    public Filme(string? nome, int id)
    {
        Id = id;
        Nome = nome;
    }

    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string? Nome { get; set; }
}