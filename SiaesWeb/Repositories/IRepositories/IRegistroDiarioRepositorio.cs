using SiaesLibraryShared.Models.Dtos;

namespace SiaesServer.Repositories.IRepositories
{
    public interface IRegistroDiarioRepositorio
    {
        Task<IEnumerable<RegistroDiarioDTO>> ObtenerRegistros(int? IdFuncionario, int? IdSubArea, DateTime FechaActividad, int IdRol);

        Task<bool> EliminarRegistroDiario(RegistroDiarioEliminarDTO dto);
    }
}
