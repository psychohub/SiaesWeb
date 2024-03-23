using SiaesLibraryShared.Models.Dtos;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesLibraryShared.Contracts;
using SiaesServer.Repositories.IRepositories;
using SiaesServer.Repositories;

namespace SiaesServer.Services
{
    public class ServicioBitacora : IServicioBitacora
    {
        private readonly IBitacora _bitacoraRepositorio;

        public ServicioBitacora(IBitacora bitacoraRepositorio)
        {
            _bitacoraRepositorio = bitacoraRepositorio;
        }

        public async Task<bool> RegistrarAccion(BitacoraDTO bitacora)
        {
            return await _bitacoraRepositorio.RegistrarAccion(bitacora);
        }

    }
}
