using System.Text.Json.Serialization;

namespace ObiletCase.Core.Models
{
    public class BusJourneyResponseModel
    {
        public int Id { get; set; }

        [JsonPropertyName("partner-id")]
        public int PartnerId { get; set; }

        [JsonPropertyName("partner-name")]
        public string PartnerName { get; set; }

        [JsonPropertyName("route-id")]
        public int RouteId { get; set; }

        [JsonPropertyName("bus-type")]
        public string BusType { get; set; }

        [JsonPropertyName("bus-type-name")]
        public string BusTypeName { get; set; }

        [JsonPropertyName("total-seats")]
        public int TotalSeats { get; set; }

        [JsonPropertyName("available-seats")]
        public int AvailableSeats { get; set; }
        public Journey Journey { get; set; }
        public List<Feature> Features { get; set; }

        [JsonPropertyName("origin-location")]
        public string OriginLocation { get; set; }

        [JsonPropertyName("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonPropertyName("is-active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("origin-location-id")]
        public int OriginLocationId { get; set; }

        [JsonPropertyName("destination-location-id")]
        public int DestinationLocationId { get; set; }

        [JsonPropertyName("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonPropertyName("cancellation-offset")]
        public int CancellationOffset { get; set; }

        [JsonPropertyName("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonPropertyName("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }

        [JsonPropertyName("display-offset")]
        public string DisplayOffset { get; set; }

        [JsonPropertyName("partner-rating")]
        public object PartnerRating { get; set; }

        [JsonPropertyName("has-dynamic-pricing")]
        public bool HasDynamicPricing { get; set; }

        [JsonPropertyName("disable-sales-without-hes-code")]
        public bool DisableSalesWithoutHesCode { get; set; }

        [JsonPropertyName("disable-single-seat-selection")]
        public bool DisableSingleSeatSelection { get; set; }

        [JsonPropertyName("change-offset")]
        public int ChangeOffset { get; set; }
        public int Rank { get; set; }

        [JsonPropertyName("display-coupon-code-input")]
        public bool DisplayCouponCodeInput { get; set; }

        [JsonPropertyName("disable-sales-without-date-of-birth")]
        public bool DisableSalesWithoutDateOfBirth { get; set; }

        [JsonPropertyName("open-offset")]
        public int? OpenOffset { get; set; }

        [JsonPropertyName("display-buffer")]
        public object DisplayBuffer { get; set; }

        [JsonPropertyName("allow-sales-foreign-passenger")]
        public bool AllowSalesForeignPassenger { get; set; }

        [JsonPropertyName("has-seat-selection")]
        public bool HasSeatSelection { get; set; }

        [JsonPropertyName("branded-fares")]
        public List<object> BrandedFares { get; set; }

        [JsonPropertyName("has-gender-selection")]
        public bool HasGenderSelection { get; set; }

        [JsonPropertyName("has-dynamic-cancellation")]
        public bool HasDynamicCancellation { get; set; }

        [JsonPropertyName("partner-terms-and-conditions")]
        public object PartnerTermsAndConditions { get; set; }

        [JsonPropertyName("partner-available-alphabets")]
        public string PartnerAvailableAlphabets { get; set; }

        [JsonPropertyName("provider-id")]
        public int ProviderId { get; set; }

        [JsonPropertyName("partner-code")]
        public string PartnerCode { get; set; }

        [JsonPropertyName("enable-full-journey-display")]
        public bool EnableFullJourneyDisplay { get; set; }

        [JsonPropertyName("provider-name")]
        public string ProviderName { get; set; }

        [JsonPropertyName("enable-all-stops-display")]
        public bool EnableAllStopsDisplay { get; set; }

        [JsonPropertyName("is-destination-domestic")]
        public bool IsDestinationDomestic { get; set; }

        [JsonPropertyName("min-len-gov-id")]
        public object MinLenGovId { get; set; }

        [JsonPropertyName("max-len-gov-id")]
        public object MaxLenGovId { get; set; }

        [JsonPropertyName("require-foreign-gov-id")]
        public bool RequireForeignGovId { get; set; }

        [JsonPropertyName("is-cancellation-info-text")]
        public bool IsCancellationInfoText { get; set; }

        [JsonPropertyName("cancellation-offset-info-text")]
        public object CancellationOffsetInfoText { get; set; }

        [JsonPropertyName("is-time-zone-not-equal")]
        public bool IsTimeZoneNotEqual { get; set; }
    }

    public class Feature
    {
        public int Id { get; set; }
        public int? Priority { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonPropertyName("back-color")]
        public string BackColor { get; set; }

        [JsonPropertyName("fore-color")]
        public string ForeColor { get; set; }
    }

    public class Journey
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public List<Stop> Stops { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Currency { get; set; }
        public string Duration { get; set; }

        [JsonPropertyName("original-price")]
        public double OriginalPrice { get; set; }

        [JsonPropertyName("internet-price")]
        public double InternetPrice { get; set; }

        [JsonPropertyName("provider-internet-price")]
        public double? ProviderInternetPrice { get; set; }
        public object Booking { get; set; }

        [JsonPropertyName("bus-name")]
        public string BusName { get; set; }
        public Policy Policy { get; set; }
        public List<string> Features { get; set; }
        public string Description { get; set; }
        public object Available { get; set; }

        [JsonPropertyName("partner-provider-code")]
        public object PartnerProviderCode { get; set; }

        [JsonPropertyName("peron-no")]
        public object PeronNo { get; set; }

        [JsonPropertyName("partner-provider-id")]
        public object PartnerProviderId { get; set; }

        [JsonPropertyName("is-segmented")]
        public bool IsSegmented { get; set; }

        [JsonPropertyName("partner-name")]
        public object PartnerName { get; set; }

        [JsonPropertyName("provider-code")]
        public object ProviderCode { get; set; }
    }

    public class Policy
    {
        [JsonPropertyName("max-seats")]
        public object MaxSeats { get; set; }

        [JsonPropertyName("max-single")]
        public int? MaxSingle { get; set; }

        [JsonPropertyName("max-single-males")]
        public int? MaxSingleMales { get; set; }

        [JsonPropertyName("max-single-females")]
        public int? MaxSingleFemales { get; set; }

        [JsonPropertyName("mixed-genders")]
        public bool MixedGenders { get; set; }

        [JsonPropertyName("gov-id")]
        public bool GovId { get; set; }
        public bool Lht { get; set; }
    }
    public class Stop
    {
        public int Id { get; set; }
        public int? KolayCarLocationId { get; set; }
        public string Name { get; set; }
        public string Station { get; set; }
        public DateTime? Time { get; set; }

        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }
    }

}