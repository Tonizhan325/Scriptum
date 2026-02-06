using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scriptum.Models
{
    public class Reseña
    {
        public int Id { get; set; }
        [Display(Name = "Id usuario")]
        public int IdUsuario { get; set; }
        [Display(Name = "Id libro")]
        public int IdLibro { get; set; }
        [Display(Name = "Puntuación")]
        [Required(ErrorMessage = "La puntuación es requerida")]
        public int Puntuacion { get; set; }

        public string? Comentario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime Fecha { get; set; }
    }
}
