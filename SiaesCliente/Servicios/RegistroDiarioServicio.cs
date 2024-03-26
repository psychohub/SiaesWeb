using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SiaesCliente.Servicios
{
    public class RegistroDiarioServicio : IServicioTRegistroDiario
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public RegistroDiarioServicio(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public Task<bool> ActualizarRegistroDiario(TRegistroDiarioDTO registroDiario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CrearRegistroDiario(TRegistroDiarioDTO registroDiario)
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

            var response = await _cliente.PostAsJsonAsync($"{Inicializar.UrlBaseApi}api/siaes/registrodiario/crear", registroDiario);
            response.EnsureSuccessStatusCode();

            var contentTemp = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public Task<bool> EliminarRegistroDiario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TRegistroDiarioDTO> ObtenerRegistroDiarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TRegistroDiarioDTO>> ObtenerRegistrosDiarios()
        {
            throw new NotImplementedException();
        }
    }
}
