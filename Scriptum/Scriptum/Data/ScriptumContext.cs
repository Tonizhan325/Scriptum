using Microsoft.EntityFrameworkCore;
using Scriptum.Models;

namespace Scriptum.Data
{
    public class ScriptumContext : DbContext
    {
        public ScriptumContext(DbContextOptions<ScriptumContext> options) : base(options)
        {
        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Genero>? Generos { get; set; }
        public DbSet<Autor>? Autores { get; set; }
        public DbSet<Reseña>? Reseñas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Poner el nombre de las tablas en singular
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Genero>().ToTable("Género");
            modelBuilder.Entity<Autor>().ToTable("Autor");
            modelBuilder.Entity<Reseña>().ToTable("Reseña");
            // Deshabilitar la eliminación en cascada en todas las relaciones
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Scriptum.Models.Subida> Subida { get; set; } = default!;
    }
}
