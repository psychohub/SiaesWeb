using SiaesLibraryShared.Models;

namespace SiaesServer.Repositories.IRepositories
{
    public interface ITUbicacionRepositorio
    {
        Task<IEnumerable<TUbicacion>> GetUbicacionAsync();
    }
}
