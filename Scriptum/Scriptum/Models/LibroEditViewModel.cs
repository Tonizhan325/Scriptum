namespace Scriptum.Models
{
    public class LibroEditViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string Idioma { get; set; }
        public decimal TamañoArchivo { get; set; }
        public string? URL { get; set; }
        public DateTime? FechaRevision { get; set; }
        public int IdUsuario { get; set; }
        public string? NombreAutor { get; set; }
        public string? IdGenero { get; set; }
        public string? EnlaceImagenExistente { get; set; } 
        public IFormFile? NuevaImagen { get; set; }
    }
}
