using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using SiaesCliente.Helpers;
using SiaesCliente.Pages.ActividadesDiarias;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SiaesCliente.Servicios
{
    public class ObtenerRegistroDiarioServicio : IRegistroDiarioServicio
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public ObtenerRegistroDiarioServicio(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<bool> EliminarRegistroDiario(RegistroDiarioEliminarDTO dto)
        {
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No se encontró el token de autenticación");
            }

            _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{Inicializar.UrlBaseApi}api/siaes/registrodiario/eliminar"),
                Content = content
            };

            // Ahora usamos la variable 'response' una única vez en este ámbito.
            var response = await _cliente.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar el registro diario: {errorMessage}");
            }
        }

        public async Task<IEnumerable<RegistroDiarioDTO>> ObtenerRegistros(int? IdFuncionario, int? IdSubArea, DateTime FechaActividad, int IdRol)
        {

            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);


            if (string.IsNullOrEmpty(token))
            {
  
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var fechaActividadString = FechaActividad.ToString("yyyy-MM-dd");
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/registrodiario/obtener/{IdFuncionario}/{IdSubArea}/{fechaActividadString}/{IdRol}");
                response.EnsureSuccessStatusCode();

                var contentTemp = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<IEnumerable<RegistroDiarioDTO>>(contentTemp);
                return resultado;

        }
    }
}
