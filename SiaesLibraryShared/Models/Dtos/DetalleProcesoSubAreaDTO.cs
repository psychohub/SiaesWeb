using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class DetalleProcesoSubAreaDTO
    {
        public int IdDetalleProcesoSubArea { get; set; }
        public int IdDetalleProceso { get; set; }
        public int IdSubArea { get; set; }
        public bool Activo { get; set; }
    }
}
