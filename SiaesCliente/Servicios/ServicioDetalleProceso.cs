using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SiaesCliente.Servicios
{
    public class ServicioDetalleProceso : IServicioDetalleProceso
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public ServicioDetalleProceso(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<int> ObtenerIdDetalleProceso(int idProceso, int idSubProceso)
        {
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No se encontró el token de autenticación");
            }

            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/detalleProceso/{idProceso}/{idSubProceso}");

            if (response.IsSuccessStatusCode)
            {
                var idDetalleProceso = await response.Content.ReadFromJsonAsync<int>();
                return idDetalleProceso;
            }

            throw new Exception("No se pudo obtener el IdDetalleProceso");
        }
    }
}
