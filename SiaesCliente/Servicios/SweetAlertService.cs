
using Microsoft.JSInterop;

namespace SiaesCliente.Servicios
{
    public class SweetAlertService
    {
        private readonly IJSRuntime _jsRuntime;

        public SweetAlertService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task MostrarMensajeExito(string mensaje)
        {
            await _jsRuntime.InvokeVoidAsync("Sweetalert2.fire", "Éxito", mensaje, "success");
        }

        public async Task MostrarMensajeError(string mensaje)
        {
            await _jsRuntime.InvokeVoidAsync("Sweetalert2.fire", "Error", mensaje, "error");
        }
    }
}
