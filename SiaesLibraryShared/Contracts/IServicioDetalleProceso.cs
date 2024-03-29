using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioDetalleProceso
    {
        Task<int> ObtenerIdDetalleProceso(int idProceso, int idSubProceso);
    }
}
