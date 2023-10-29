using ObiletCase.Core.Models;

namespace ObiletCase.ApiClient.ApiClientServices
{
    public interface IJourneyClientService
    {
        Task<ResponseBaseModel<List<BusJourneyResponseModel>>> GetBusJourneys(RequestBaseModel<BusJourneyRequestModel> request);
    }
}