using SiaesLibraryShared.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IRegistroDiarioServicio
    {
        Task<IEnumerable<RegistroDiarioDTO>> ObtenerRegistros(int? IdFuncionario, int? IdSubArea, DateTime FechaActividad, int IdRol);
        Task<bool> EliminarRegistroDiario(RegistroDiarioEliminarDTO dto);
    }
}
