using System.ComponentModel.DataAnnotations;

namespace LibreriaDigitalApi.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; } = string.Empty; // Requisito: Título

    [Required]
    public string Autor { get; set; } = string.Empty; // Requisito: Autor

    public int AnioPublicacion { get; set; } // Requisito: Año

    public string? ImagenPortada { get; set; } // Requisito: Imagen (opcional)

    [Range(1, 5)]
    public int Calificacion { get; set; } // Requisito: 1 a 5 estrellas

    public string? Resenia { get; set; } // Requisito: Reseña escrita

    // Relación con el Usuario
    public int? UserId { get; set; }
}