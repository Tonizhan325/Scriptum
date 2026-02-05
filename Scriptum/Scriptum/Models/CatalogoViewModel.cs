namespace Scriptum.Models
{
    public class CatalogoViewModel
    {
        public IEnumerable<Libro> Libros { get; set; }
        public IEnumerable<Genero> Generos { get; set; }
    }
}
