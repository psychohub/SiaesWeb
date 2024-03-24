using SiaesLibraryShared.Models;

namespace SiaesServer.Repositories.IRepositories
{
    public interface ISubProcesoRepositorio
    {
        Task<IEnumerable<TSubProceso>> GetSubProcesosByProcesoIdAsync(int procesoId);
    }
}
