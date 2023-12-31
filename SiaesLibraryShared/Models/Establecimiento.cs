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
        public string CodEstablecimiento { get; set; }
        public ICollection<UsuarioEstablecimiento> UsuarioEstablecimientos { get; set; }
    }
}
