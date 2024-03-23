using System.Text.Json.Serialization;

namespace SiaesCliente.Helpers
{
    public class OpenStreetMapGeocodeResponse
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
    }
}
