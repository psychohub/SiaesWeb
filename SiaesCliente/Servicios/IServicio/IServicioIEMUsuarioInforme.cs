using SiaesLibraryShared.Models;

namespace SiaesCliente.Servicios.IServicio
{
    public interface IServicioIEMUsuarioInforme
    {
        Task<List<IEMInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento);
        Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme);
        Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme);
        Task<List<IEMInforme>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento);
        Task<IEMInforme> ObtenerInformePorCodigo(string codigoInforme);
        Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes();
    }
}
