using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El establecimiento es obligatorio")]
        public string Establecimiento { get; set; }
        public string SelectedPerfil { get; set; }
    }
}
