using ObiletCase.Core.Models;

namespace ObiletCase.UI.ViewModels
{
    public class BusLocationViewModel
    {
        public DateTime Date { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public List<BusLocationResponseModel> BusLocations { get; set; }
    }
}