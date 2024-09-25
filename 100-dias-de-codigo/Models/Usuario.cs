using System.ComponentModel.DataAnnotations;

namespace _100_dias_de_codigo;

public class Usuario
{
    [Key] 
     public int Id;
    [StringLength(100)] [Required]
     public string? Nome;
    [StringLength(100)] [Required]
     public string? Email;
    [DataType(DataType.Password)] [Required]
     public string? Password;
}