using SiaesLibraryShared.Models;

namespace SiaesServer.Repositories.IRepositories
{
    public interface IProcesoRepositorio
    {
        Task<IEnumerable<TProceso>> GetProcesosAsync();
  
    }
}
