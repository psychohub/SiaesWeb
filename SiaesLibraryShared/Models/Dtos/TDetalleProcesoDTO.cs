using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class TDetalleProcesoDTO
    {
        public int IdDetalleProceso { get; set; }
        public int IdProceso { get; set; }
        public int IdSubProceso { get; set; }
        public int IdActividad { get; set; }
    }
}
