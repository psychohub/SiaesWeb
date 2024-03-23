using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SiaesCliente.Helpers
{
    public class JSHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public JSHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<GeolocationResult> GetGeolocationAsync()
        {
            return await _jsRuntime.InvokeAsync<GeolocationResult>("getGeolocation");
        }
    }
    public class GeolocationResult
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
