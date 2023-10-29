using System.Text.Json.Serialization;

namespace ObiletCase.Core.Models
{
    public class SessionResponseModel
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
        public object Affiliate { get; set; }
        [JsonPropertyName("device-type")]
        public int DeviceType { get; set; }
        public object Device { get; set; }
        [JsonPropertyName("ip-country")]
        public string IpCountry { get; set; }
    }
}