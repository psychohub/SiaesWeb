using SiaesLibraryShared.Models;

namespace SiaesServer.Repositories.IRepositories
{
    public interface IActividadMacroRepositorio
    {
        Task<IEnumerable<TActividadMacro>> GetActividadesMacroAsync();
    }
}
