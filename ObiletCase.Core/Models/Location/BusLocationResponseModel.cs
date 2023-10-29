using System.Text.Json.Serialization;

namespace ObiletCase.Core.Models
{
    public class BusLocationResponseModel
    {
        public int Id { get; set; }

        [JsonPropertyName("parent-id")]
        public int ParentId { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        public int Zoom { get; set; }

        [JsonPropertyName("tz-code")]
        public string TzCode { get; set; }

        [JsonPropertyName("weather-code")]
        public object WeatherCode { get; set; }

        public int Rank { get; set; }

        [JsonPropertyName("reference-code")]
        public string ReferenceCode { get; set; }

        [JsonPropertyName("city-id")]
        public int? CityId { get; set; }

        [JsonPropertyName("reference-country")]
        public object ReferenceCountry { get; set; }

        [JsonPropertyName("country-id")]
        public int? CountryId { get; set; }

        public string Keywords { get; set; }

        [JsonPropertyName("city-name")]
        public string CityName { get; set; }

        [JsonPropertyName("languages")]
        public object Languages { get; set; }

        [JsonPropertyName("country-name")]
        public string CountryName { get; set; }
        public object Code { get; set; }

        [JsonPropertyName("show-country")]
        public bool ShowCountry { get; set; }

        [JsonPropertyName("area-code")]
        public object AreaCode { get; set; }

        [JsonPropertyName("long-name")]
        public string LongName { get; set; }

        [JsonPropertyName("is-city-center")]
        public bool IsCityCenter { get; set; }
    }

    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? Zoom { get; set; }
    }
}