using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using SiaesCliente.Helpers;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SiaesCliente.Servicios
{
    public class TiempoInvertidoServicio : IServicioTiempoInvertidoServicio
    {
        private readonly HttpClient? _cliente;
        private readonly ILocalStorageService? _localStorage;
        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        public TiempoInvertidoServicio(HttpClient cliente,
            ILocalStorageService localStorage,
            AuthenticationStateProvider estadoProveedorAutenticacion)
        {
            _cliente = cliente;
            _localStorage = localStorage;
            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
        }

        public async Task<decimal> GetTotalTiempoInvertidoAsync(int idFuncionario, DateTime fechaActividad)
        {
            var token = await _localStorage.GetItemAsync<string>(Inicializar.Token_Local);
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No se encontró el token de autenticación");
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _cliente.GetAsync($"{Inicializar.UrlBaseApi}api/siaes/registrodiario/tiempoinvertido/{idFuncionario}/{fechaActividad}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var totalTiempoInvertido = await response.Content.ReadFromJsonAsync<decimal>();
                return totalTiempoInvertido;
            }

            // Devolver un valor predeterminado si la respuesta no tiene éxito.
            return 0;


        }
    }
}

