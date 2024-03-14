using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class UsuarioEstablecimientoPerfil
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EstablecimientoId { get; set; }
        public Establecimiento Establecimiento { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public string NombreUsuario { get; set; }

       
    }
}
