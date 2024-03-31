using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class UsuarioCambiarClaveDTO
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La nueva clave es obligatoria.")]
        public string NuevaClave { get; set; }
    }
}
