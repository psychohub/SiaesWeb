using SiaesLibraryShared.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioTRegistroDiario
    {
        Task<List<TRegistroDiarioDTO>> ObtenerRegistrosDiarios();
        Task<TRegistroDiarioDTO> ObtenerRegistroDiarioPorId(int id);
        Task<bool> CrearRegistroDiario(TRegistroDiarioDTO registroDiario);
        Task<bool> ActualizarRegistroDiario(TRegistroDiarioDTO registroDiario);
        Task<bool> EliminarRegistroDiario(int id);
    }
}
