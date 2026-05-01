using System.ComponentModel.DataAnnotations;

namespace LibreriaDigitalApi.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty; // Requisito: Nombre

    [Required]
    public string Apellido { get; set; } = string.Empty; // Requisito: Apellido

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty; // Requisito: Email

    [Required]
    public string Password { get; set; } = string.Empty; // Requisito: Contraseña

    // Relación: Un usuario tiene muchos libros
    public ICollection<Book> Books { get; set; } = new List<Book>();
}