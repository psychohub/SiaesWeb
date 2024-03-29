using Microsoft.JSInterop;

namespace SiaesCliente.Helpers
{
    public static class IJsHelper
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeAsync<object>("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeAsync<object>("ShowToastr", "error", message);
        }
    }

}
