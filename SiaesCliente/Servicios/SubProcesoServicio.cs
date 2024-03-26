using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SiaesCliente.Servicios
{
    public class SubProcesoServicio : IServicioSubProcesoRepositorio
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public SubProcesoServicio(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<IEnumerable<SubProcesoDTO>> GetSubProcesosByProcesoIdAsync(int procesoId)
        {
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);

            if (string.IsNullOrEmpty(token))
            {
                // Lanzar una excepción con el mensaje de error
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/registrodiario/subproceso/{procesoId}");
            response.EnsureSuccessStatusCode();

            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<IEnumerable<SubProcesoDTO>>(contentTemp);
            return resultado;


        }
    }
}
