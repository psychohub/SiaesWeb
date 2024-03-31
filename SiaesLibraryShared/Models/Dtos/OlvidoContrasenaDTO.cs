using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class OlvidoContrasenaDTO
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Correo { get; set; }
    }
}
