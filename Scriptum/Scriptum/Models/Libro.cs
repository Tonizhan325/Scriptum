using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scriptum.Models
{

    public enum Tipo
    {
        LIBRO,
        COMIC,
        REVISTA,
        ARTICULO
    }


    public class Libro
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es requerido")]
        public string Titulo { get; set; }
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
        public string Idioma { get; set; }

        [Display(Name = "Tamaño del archivo")]
        public decimal TamañoArchivo { get; set; }
        public string? URL { get; set; }

        [Display(Name = "Fecha de subida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "timestamp without time zone")]

        public DateTime FechaSubida { get; set; }
        [Display(Name = "Fecha de revisión")]
        [Column(TypeName = "timestamp without time zone")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRevision { get; set; }
        [Display(Name = "Id usuario")]
        public int IdUsuario { get; set; }
        [Display(Name = "Id género")]
        public string? IdGenero { get; set; }

        [Display(Name = "Nombre de autor")]
        public string? NombreAutor { get; set; }
        public string? EnlaceImagen { get; set; }
        public Genero? Genero { get; set; }
        public Tipo? Tipo { get; set; }

    }
}
