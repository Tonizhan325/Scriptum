using System.ComponentModel.DataAnnotations;

namespace Scriptum.Models
{
    public class Subida
    {
        public int Id { get; set; }

        [Display(Name = "Id usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Fecha de subida")]
        public DateTime FechaSubida { get; set; }

        public string? URL { get; set; }

        [Display(Name = "Id libro")]
        public int IdLibro { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        
    }
}
