using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;

namespace SiaesServer.Repositories.IRepositories
{
    public interface ITRegistroDiario
    {
        Task<List<TRegistroDiarioDTO>> ObtenerRegistrosDiarios();
        Task<TRegistroDiarioDTO> ObtenerRegistroDiarioPorId(int id);
        Task<bool> CrearRegistroDiario(TRegistroDiario registroDiario);
        Task<bool> ActualizarRegistroDiario(TRegistroDiario registroDiario);
        Task<bool> EliminarRegistroDiario(int id);
        Task<bool> CrearRegistroDiario(RegistroDiarioCreacionDTO registroDiarioCreacionDTO);
    }
}
