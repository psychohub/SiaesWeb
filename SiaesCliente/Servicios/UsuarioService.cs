using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http;
using SiaesCliente.Helpers;
using System.Net.Http.Headers;

namespace SiaesCliente.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public UsuarioService(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<UsuarioLocalStorage> ObtenerUsuarioId(string nombreUsuario, int codEstablecimiento)
        {
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);

            if (string.IsNullOrEmpty(token))
            {
                // Lanzar una excepción con el mensaje de error
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.GetAsync($"api/siaes/obtenerusuarioId/{nombreUsuario}/{codEstablecimiento}");
            var contentTemp = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<JObject>(contentTemp);

            if (resultado == null)
            {
                return null;
            }

            var usuario = resultado["result"] as JObject;

            if (usuario != null)
            {
                var id = usuario["id"]?.Value<int>();
                var idRol = usuario["idRol"]?.Value<int>();
                var idSubArea = usuario["idSubArea"]?.Value<int>();

                if (id.HasValue && idRol.HasValue && idSubArea.HasValue)
                {
                    var usuarioLocalStorage = new UsuarioLocalStorage
                    {
                        Id = id.Value,
                        IdRol = idRol.Value,
                        IdSubArea = idSubArea.Value
                    };

                    await _localStorage.SetItemAsync("UsuarioLocalStorage", usuarioLocalStorage);

                    return usuarioLocalStorage;
                }
            }

            return null;

        }
    }
}
