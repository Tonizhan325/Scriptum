using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scriptum.Controllers;
using Scriptum.Models;

namespace Scriptum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Genero>? Generos { get; set; }
        public DbSet<Reseña>? Reseñas { get; set; }
        public DbSet<Subida>? Subidas { get; set; }
        public DbSet<Descarga>? Descargas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Poner el nombre de las tablas en singular
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Genero>().ToTable("Género");
            modelBuilder.Entity<Reseña>().ToTable("Reseña");
            modelBuilder.Entity<Subida>().ToTable("Subida");
            modelBuilder.Entity<Descarga>().ToTable("Descarga");

            // Deshabilitar la eliminación en cascada en todas las relaciones
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
