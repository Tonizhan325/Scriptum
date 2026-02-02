using System.ComponentModel.DataAnnotations;

namespace Scriptum.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contraseña { get; set; }
        [Display(Name = "Correo eléctronico")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string? Email { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime fechaRegistro { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Id rol")]
        public int IdRol { get; set; }
    }
}
