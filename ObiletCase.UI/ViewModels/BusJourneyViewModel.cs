using ObiletCase.Core.Models;

namespace ObiletCase.UI.ViewModels
{
    public class BusJourneyViewModel
    {
        public BusJourneyViewModel()
        {
            BusJourneys = new List<BusJourneyResponseModel>();
        }
        public string OriginLocation { get; set; }
        public DateTime? Date { get; set; }
        public string DestinationLocation { get; set; }

        public List<BusJourneyResponseModel> BusJourneys { get; set; }
    }
}