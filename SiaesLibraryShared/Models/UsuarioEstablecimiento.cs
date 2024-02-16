using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class UsuarioEstablecimiento
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EstablecimientoId { get; set; }
        public Establecimiento Establecimiento { get; set; }


        public ICollection<UsuarioEstablecimientoPerfil> UsuarioEstablecimientoPerfiles { get; set; }
    }
}
