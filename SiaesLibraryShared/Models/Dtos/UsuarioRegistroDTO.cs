using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class UsuarioRegistroDTO
    {


        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El codigo es obligatorio")]
        public int CodEstablecimiento { get; set; }

        [Required(ErrorMessage = "La clave es requerida")]
        public string Clave { get; set; } = string.Empty;
        public int Perfil { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCaducidad { get; set; } = DateTime.Now;
        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
