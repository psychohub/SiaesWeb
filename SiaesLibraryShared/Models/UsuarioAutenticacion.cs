using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class UsuarioAutenticacion
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string NombreUsuario { get; set; } = string.Empty;
        public int CodEstablecimiento { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; } = string.Empty;
        public int Perfil { get; set; }


    }
}
