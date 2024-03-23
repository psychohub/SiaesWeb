using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using System.Net.Http.Json;

namespace SiaesCliente.Servicios
{
    public class ServicioBitacoraCliente : IServicioBitacora
    {
        private readonly HttpClient _httpClient;

        public ServicioBitacoraCliente(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegistrarAccion(BitacoraDTO bitacora)
        {
            var response = await _httpClient.PostAsJsonAsync("api/siaes/bitacora", bitacora);
            return response.IsSuccessStatusCode;
        }
    }
}
