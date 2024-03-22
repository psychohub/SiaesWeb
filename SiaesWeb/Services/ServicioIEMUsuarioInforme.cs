using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesServer.Repositories;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class ServicioIEMUsuarioInforme : IServicioIEMUsuarioInforme
    {
        private readonly IServicioIEMUsuarioInforme _usuarioInformeRepositorio;

        public ServicioIEMUsuarioInforme(IServicioIEMUsuarioInforme usuarioRepositorio)
        {
            _usuarioInformeRepositorio = usuarioRepositorio;
        }
        public async Task<List<IEMUsuarioInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            return null;
        }

        public async Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            //return await _repositorio.AsociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
            return false;
        }

        public async Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            //return await _repositorio.DesasociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
            return false;
        }



        public async Task<IEnumerable<IEMInforme>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento)
        {
            var informesDisponibles = await _usuarioInformeRepositorio.ObtenerInformesDisponibles(nombreUsuario, codEstablecimiento);
            return informesDisponibles.ToList();
        }

        public async Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes()
        {
            return await _usuarioInformeRepositorio.ObtenerTodosLosInformes();


        }

        Task<List<IEMInforme>> IServicioIEMUsuarioInforme.ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            throw new NotImplementedException();
        }

        public Task<IEMInforme> ObtenerInformePorCodigo(string codigoInforme)
        {
            throw new NotImplementedException();
        }
    }
}