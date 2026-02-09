namespace Scriptum.Models
{
    public class CatalogoViewModel
    {
        public IEnumerable<Libro> Libros { get; set; } = Enumerable.Empty<Libro>();
        public IEnumerable<Genero> Generos { get; set; } = Enumerable.Empty<Genero>();
    }
}
