using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class ServicioIEMUsuarioInforme : IServicioIEMUsuarioInforme
    {
        private readonly IIEMUsuarioInforme _repositorio;

        public ServicioIEMUsuarioInforme(IIEMUsuarioInforme repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<IEMUsuarioInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            return await _repositorio.ObtenerInformesAsociados(nombreUsuario, codEstablecimiento);
        }

        public async Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            return await _repositorio.AsociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
        }

        public async Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            return await _repositorio.DesasociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
        }
    }
}