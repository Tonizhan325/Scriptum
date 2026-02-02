using System.ComponentModel.DataAnnotations;

namespace Scriptum.Models
{
    public class Autor
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public string? Nacionalidad { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

    }
}
