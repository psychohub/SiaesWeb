using SiaesLibraryShared.Models;

namespace SiaesServer.Repositories.IRepositories
{
    public interface IIEMUsuarioInforme
    {
        Task<List<IEMUsuarioInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento);
        Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme);
        Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme);
        Task<IEnumerable<IEMInforme>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento);
        Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes();
    }
}
