using System.ComponentModel.DataAnnotations;

namespace LibreriaDigitalApi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Autor { get; set; } = string.Empty;

        public int AnioPublicacion { get; set; }

        public string? ImagenPortada { get; set; }

        public int Calificacion { get; set; }

        public string? Resenia { get; set; }

        // El signo ? hace que el usuario NO sea obligatorio, 
        // así se quita el error 500 de la base de datos.
        public int? UserId { get; set; }
    }
}
