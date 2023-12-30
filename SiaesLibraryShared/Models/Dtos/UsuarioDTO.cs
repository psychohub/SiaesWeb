using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class UsuarioDTO
    {
       
        public int Id { get; set; }

         public string NombreUsuario { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;


        public string Correo { get; set; } = string.Empty;

        public int CodEstablecimiento { get; set; }

        public int Perfil { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCaducidad { get; set; } = DateTime.Now;
        public string? UsuarioCreacion { get; set; } = string.Empty;

        public string? UsuarioModificacion { get; set; } = string.Empty;
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; } = DateTime.Now;
    }
}
