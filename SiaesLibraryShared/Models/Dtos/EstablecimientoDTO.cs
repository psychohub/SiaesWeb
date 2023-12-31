using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class EstablecimientoDTO
    {
        public int CodEstablecimiento { get; set; }
        public List<UsuarioEstablecimientoDTO> UsuarioEstablecimientos { get; set; }
    }
}
