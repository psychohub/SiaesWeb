using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SiaesCliente.Servicios
{
    public class ServicioIEMUsuarioInforme : IServicioIEMUsuarioInforme
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public ServicioIEMUsuarioInforme(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            var token = await ObtenerToken();
            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.PostAsJsonAsync($"{Inicializar.UrlBaseApi}api/siaes/asociar/{nombreUsuario}/{codEstablecimiento}", codigosInforme);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            var token = await ObtenerToken();
            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.DeleteAsync($"{Inicializar.UrlBaseApi}api/siaes/desasociar/{nombreUsuario}/{codEstablecimiento}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<IEMUsuarioInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            var token = await ObtenerToken();
            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/informes/asociados/{nombreUsuario}/{codEstablecimiento}");
            response.EnsureSuccessStatusCode();

            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<IEMUsuarioInforme>>(contentTemp);
            return resultado;
        }

        public async Task<IEnumerable<IEMInforme>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento)
        {
            var token = await ObtenerToken();
            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/informes/disponibles/{nombreUsuario}/{codEstablecimiento}");
            response.EnsureSuccessStatusCode();

            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<IEnumerable<IEMInforme>>(contentTemp);
            return resultado;
        }

        public async  Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes()
        {
            var token = await ObtenerToken();
            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/informes");
            response.EnsureSuccessStatusCode();

            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<IEnumerable<IEMInforme>>(contentTemp);
            return resultado;
        }

        private async Task<string> ObtenerToken()
        {
            var estado = await _estadoProveedorAutenticacion.GetAuthenticationStateAsync();
            var usuario = estado.User;

            if (usuario.Identity.IsAuthenticated)
            {
                return await _localStorage.GetItemAsStringAsync("token");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
