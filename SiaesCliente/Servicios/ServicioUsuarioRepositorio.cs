using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SiaesCliente.Servicios
{
  
    public class ServicioUsuarioRepositorio : IServicioUsuarioRepositorio
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public ServicioUsuarioRepositorio(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }


        public async Task<AsociarUsuarioResponse> ActualizarUsuario(Usuario usuario)
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
            var response = await _cliente.PutAsJsonAsync($"{Inicializar.UrlBaseApi}api/siaes/asociar", usuario);

            try
            {
                response.EnsureSuccessStatusCode();
                var contentTemp = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestasAPI>(contentTemp);

                if (resultado.IsSuccess)
                {
                    return new AsociarUsuarioResponse { Exitoso = true };
                }
                else
                {
                    return new AsociarUsuarioResponse { Exitoso = false, Errores = resultado.ErrorsMessages };
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de la solicitud HTTP
                var errorMessage = await response.Content.ReadAsStringAsync();

                throw new Exception($"Error al actualizar el usuario: {errorMessage}", ex);
            }
            catch (JsonException ex)
            {
                // Manejar errores de deserialización JSON
                var errorMessage = await response.Content.ReadAsStringAsync();

                throw new Exception($"Error al deserializar la respuesta JSON: {errorMessage}", ex);
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                throw new Exception($"Error al actualizar el usuario: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Rol>> GetRoles()
        {
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/roles");
            response.EnsureSuccessStatusCode();
            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<IEnumerable<Rol>>(contentTemp);
            return resultado;
        }

        public async Task<IEnumerable<SubArea>> GetSubAreas()
        {
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/subareas");
            response.EnsureSuccessStatusCode();
            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<IEnumerable<SubArea>>(contentTemp);
            return resultado;

        }

        public async Task<Usuario> GetUsuarioById(int usuarioId)
        {
            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/{usuarioId}");
            var respuestaApi = await response.Content.ReadFromJsonAsync<RespuestasAPI>();

            if (response.IsSuccessStatusCode && respuestaApi.IsSuccess)
            {
                return (Usuario)respuestaApi.Result;
            }
            else
            {
                throw new Exception($"Error al obtener el usuario por Id: {string.Join(", ", respuestaApi.ErrorsMessages)}");
            }
        }

        public async Task<Usuario?> GetUsuarioByNombreUsuario(string nombreUsuario)
        {
            try
            {
                var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/nombreUsuario/{nombreUsuario}");

                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
                    return usuario;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // El usuario no existe, retornar null
                    return null;
                }
                else
                {
                    // Manejar otros errores de la API
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener el usuario por nombre de usuario: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones de red u otros errores
                Console.WriteLine($"Error al obtener usuario por nombre de usuario: {ex.Message}");
                throw new Exception($"Error al obtener el usuario por nombre de usuario: {ex.Message}", ex);
            }
        }

        public async Task<Usuario> ObtenerUsuarioId(string nombreUsuario, int codEstablecimiento)
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

            var response = await client.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/obtenerusuarioId?nombreUsuario={nombreUsuario}&codEstablecimiento={codEstablecimiento}");

            if (response.IsSuccessStatusCode)
            {
                var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
                return usuario;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // El usuario no existe, retornar null
                return null;
            }
            else
            {
                // Manejar otros errores de la API
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener el usuario por nombre de usuario: {errorMessage}");
            }
        }

    }
}
