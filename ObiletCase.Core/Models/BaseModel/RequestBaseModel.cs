using System.Text.Json.Serialization;

namespace ObiletCase.Core.Models
{
    public class RequestBaseModel<T>
    {
        public RequestBaseModel()
        {
            DeviceSession = new DeviceSession();
        }
        [JsonPropertyName("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class DeviceSession
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
    }
}