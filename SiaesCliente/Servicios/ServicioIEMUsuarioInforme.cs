using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

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
            // Obtener el token de autenticación desde el almacenamiento local
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);


            // Verificar si el token está disponible
            if (string.IsNullOrEmpty(token))
            {
                // Lanzar una excepción con el mensaje de error
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
            // Obtener el token de autenticación desde el almacenamiento local
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);


            // Verificar si el token está disponible
            if (string.IsNullOrEmpty(token))
            {
                // Lanzar una excepción con el mensaje de error
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _cliente.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{Inicializar.UrlBaseApi}api/siaes/desasociar/{nombreUsuario}/{codEstablecimiento}"),
               
            });

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEMInforme> ObtenerInformePorCodigo(string codigoInforme)
        {
            // Obtener el token de autenticación desde el almacenamiento local
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);

            // Verificar si el token está disponible
            if (string.IsNullOrEmpty(token))
            {
                // Lanzar una excepción con el mensaje de error
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/informes/codigo/{codigoInforme}");
            response.EnsureSuccessStatusCode();
            var contentTemp = await response.Content.ReadAsStringAsync();

            try
            {
                var informeAPIDTO = JsonConvert.DeserializeObject<InformeAPIDTO>(contentTemp);

                var informe = new IEMInforme
                {
                    COD_INFORME = informeAPIDTO.COD_INFORME,
                    DSC_INFORME = informeAPIDTO.DSC_INFORME,
                    Log_Activo = informeAPIDTO.Log_Activo,
                    Tipo = informeAPIDTO.Tipo,
                    Log_Activo_SACCE = informeAPIDTO.Log_Activo_SACCE
                };
                return informe;
            }
            catch (JsonException ex)
            {
                // Manejar el error de deserialización
                Console.WriteLine($"Error al deserializar la respuesta JSON: {ex.Message}");
                // Puedes lanzar una excepción, devolver un valor predeterminado o tomar alguna otra acción según tus necesidades
                throw;
            }

        }

        public async Task<List<IEMInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/informes/asociados/{nombreUsuario}/{codEstablecimiento}");
            response.EnsureSuccessStatusCode();
            var contentTemp = await response.Content.ReadAsStringAsync();
            var informesUsuarioAsociadosDTO = JsonConvert.DeserializeObject<List<IEMUsuarioInformeDTO>>(contentTemp);

            var informes = new List<IEMInforme>();

            foreach (var informeUsuarioDTO in informesUsuarioAsociadosDTO)
            {
                var informe = await ObtenerInformePorCodigo(informeUsuarioDTO.COD_INFORME);
                informes.Add(informe);
            }

            return informes;
        }

        public async Task<IEnumerable<IEMInforme>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento)
        {
            // Obtener el token de autenticación desde el almacenamiento local
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);


            // Verificar si el token está disponible
            if (string.IsNullOrEmpty(token))
            {
                // Lanzar una excepción con el mensaje de error
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/informes/disponibles/{nombreUsuario}/{codEstablecimiento}");
            response.EnsureSuccessStatusCode();

            var contentTemp = await response.Content.ReadAsStringAsync();
            var informesDisponibles = JsonConvert.DeserializeObject<List<IEMInforme>>(contentTemp);
            return informesDisponibles;


        }

        public async Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes()
        {
            // Obtener el token de autenticación desde el almacenamiento local
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);


            // Verificar si el token está disponible
            if (string.IsNullOrEmpty(token))
            {
                // Lanzar una excepción con el mensaje de error
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/informes");
            response.EnsureSuccessStatusCode();

            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<IEnumerable<IEMInforme>>(contentTemp);
            return resultado;
        }

      
    }
}
