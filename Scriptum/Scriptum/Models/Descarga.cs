using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scriptum.Models
{
    public class Descarga
    {
        public int Id { get; set; }
        [Display(Name = "Id usuario")]
        public int IdUsuario { get; set; }
        [Display(Name = "Id libro")]
        public int IdLibro { get; set; }
        [Display(Name = "Fecha de descarga")]
        [Column(TypeName = "timestamp without time zone")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDescarga { get; set; }
        [Display(Name = "Dirección ip")]
        public string Ip { get; set; }

    }

}
