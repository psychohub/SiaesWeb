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
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; } = string.Empty; // Este debe corresponder a 'Password' en el DTO

        [Required(ErrorMessage = "El establecimiento es obligatorio")]
        public int CodEstablecimiento { get; set; } // Este debe corresponder a 'Establecimiento' en el DTO

        public int Perfil { get; set; } // Este corresponde a 'SelectedPerfil' en el DTO
    }
}

