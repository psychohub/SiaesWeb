using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class Establecimiento
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public int CodEstablecimiento { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<UsuarioEstablecimientoPerfil> UsuarioEstablecimientoPerfiles { get; set; }
        public ICollection<UsuarioEstablecimiento> UsuarioEstablecimientos { get; set; }
    }
}
