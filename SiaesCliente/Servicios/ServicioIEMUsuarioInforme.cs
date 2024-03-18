using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;

namespace SiaesCliente.Servicios
{
    public class ServicioIEMUsuarioInforme : IServicioIEMUsuarioInforme
    {
        public Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            throw new NotImplementedException();
        }

        public Task<List<IEMUsuarioInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            throw new NotImplementedException();
        }
    }
}
