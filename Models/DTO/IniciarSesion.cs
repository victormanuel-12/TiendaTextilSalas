using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace proyectoTienda.Models.DTO
{
    public class IniciarSesion
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int IDIniciarSesion { get; set; }

      [Required]
      [EmailAddress]
      [StringLength(255)]
      [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El formato de correo electrónico no es válido.")]
      public string? Email { get; set; }

      [Required]
      [StringLength(255, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
      [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9]).+$", ErrorMessage = "La contraseña debe contener al menos una letra mayúscula y un número.")]
      public string? Contrasena { get; set; }
    }
}