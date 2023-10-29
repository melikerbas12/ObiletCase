namespace ObiletCase.Core.Models
{
    public class BusLocationRequestModel
    {
        public DeviceSession DeviceSession { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
        public string Data { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
    }
}