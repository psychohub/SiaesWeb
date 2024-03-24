using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioProcesoRepositorio
    {
        Task<IEnumerable<ProcesoDTO>> GetProcesosAsync();
    }
}
