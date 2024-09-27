using System.ComponentModel.DataAnnotations;

namespace _100_dias_de_codigo;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)][Required]
    public string? Nome { get; set; }
    [StringLength(100)]
    [Required]
    public string? Email { get; set; }
    [DataType(DataType.Password)] [Required]
     public string? Password { get; set; }
}