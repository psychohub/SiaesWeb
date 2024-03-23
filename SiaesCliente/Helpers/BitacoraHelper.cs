using Microsoft.JSInterop;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

namespace SiaesCliente.Helpers
{
    public class BitacoraHelper
    {
        private static IServicioBitacora _servicioBitacora;

        public static void ConfigurarServicioBitacora(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            _servicioBitacora = serviceProvider.GetRequiredService<IServicioBitacora>();
        }
        public static async Task RegistrarAccionEnBitacora(string accion, int? idRegistroAfectado, string nombreTabla, string usuarioRegistro, IJSRuntime jsRuntime)
        {
            if (_servicioBitacora != null)
            {
                var bitacora = new BitacoraDTO
                {
                    UsuarioRegistro = usuarioRegistro,
                    FechaRegistro = DateTime.Now,
                    Accion = accion,
                    IdRegistroAfectado = idRegistroAfectado,
                    NombreTabla = nombreTabla,
                    IP = await GetIPAddress(jsRuntime),
                    Host = Dns.GetHostName(),
                    NombreEquipo = Environment.MachineName,
                    RemoteIPAddress = await GetRemoteIPAddress(),
                    RemoteHostIPAddress = await GetRemoteIPAddress(),
                    Geolocalizacion = "Ubicación desconocida"
                };

                await _servicioBitacora.RegistrarAccion(bitacora);
            }
        }

        private static async Task<string> GetIPAddress(IJSRuntime jsRuntime)
        {
            try
            {
                return await jsRuntime.InvokeAsync<string>("eval", "return window.location.hostname;");
            }
            catch (Exception)
            {
                // Manejar la excepción en caso de error
            }

            return "IP desconocida";
        }

        private static async Task<string> GetRemoteIPAddress()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync("https://api.ipify.org");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                // Manejar la excepción en caso de error
            }
            return "Dirección IP remota desconocida";
        }
    }
}
