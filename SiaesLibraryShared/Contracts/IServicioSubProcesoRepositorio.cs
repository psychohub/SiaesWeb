using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioSubProcesoRepositorio
    {
        Task<IEnumerable<SubProcesoDTO>> GetSubProcesosByProcesoIdAsync(int procesoId);
    }
}
