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
            // Obtener la lista de todos los informes disponibles
            var informesTotales = await ObtenerTodosLosInformes();

            // Obtener la lista de informes asociados al usuario y establecimiento
            var informesAsociados = await ObtenerInformesAsociados(nombreUsuario, codEstablecimiento);

            // Comparar ambas listas y obtener los informes disponibles (no asociados)
            var informesDisponibles = informesTotales.Except(informesAsociados.Select(i => i.Informe));

            return informesDisponibles;
        }

        public async Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes()
        {
            return await _usuarioInformeRepositorio.ObtenerTodosLosInformes();


        }
    }
}