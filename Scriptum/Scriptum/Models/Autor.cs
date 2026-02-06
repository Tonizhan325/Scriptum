using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scriptum.Models
{
    public class Autor
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public string? Nacionalidad { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? FechaNacimiento { get; set; }

    }
}
