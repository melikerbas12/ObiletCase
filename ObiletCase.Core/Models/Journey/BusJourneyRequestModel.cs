using System.Text.Json.Serialization;

namespace ObiletCase.Core.Models
{
    public class BusJourneyRequestModel
    {
        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }

        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }

        [JsonPropertyName("departure-date")]
        public string DepartureDate { get; set; }
    }
}