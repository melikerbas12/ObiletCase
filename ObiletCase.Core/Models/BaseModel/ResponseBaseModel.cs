using System.Text.Json.Serialization;

namespace ObiletCase.Core.Models
{
    public class ResponseBaseModel<T>
    {
        public string Status { get; set; }
        public object Message { get; set; }

        [JsonPropertyName("user-message")]
        public object UserMessage { get; set; }

        [JsonPropertyName("api-request-id")]
        public object ApiRequestId { get; set; }
        public string Controller { get; set; }

        [JsonPropertyName("client-request-id")]
        public object ClientRequestId { get; set; }

        [JsonPropertyName("web-correlation-id")]
        public object WebCorrelationId { get; set; }

        [JsonPropertyName("correlation-id")]
        public string CorrelationId { get; set; }
        public object Parameters { get; set; }
        public T Data { get; set; }
    }
}