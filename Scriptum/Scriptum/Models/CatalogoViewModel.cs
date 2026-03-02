namespace Scriptum.Models
{
    public class CatalogoViewModel
    {
        public IEnumerable<Libro> Libros { get; set; } = Enumerable.Empty<Libro>();
        public IEnumerable<Genero> Generos { get; set; } = Enumerable.Empty<Genero>();

        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public string FiltroBusqueda { get; set; }
        public string? GeneroSeleccionado { get; set; }
        public string? TipoSeleccionado { get; set; }
    }
}
