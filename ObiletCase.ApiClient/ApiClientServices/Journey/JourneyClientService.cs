using System.Net.Http.Json;
using ObiletCase.Core.Models;

namespace ObiletCase.ApiClient.ApiClientServices
{
    public class JourneyClientService : IJourneyClientService
    {
        private readonly HttpClient _apiClient;
        public JourneyClientService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<ResponseBaseModel<List<BusJourneyResponseModel>>> GetBusJourneys(RequestBaseModel<BusJourneyRequestModel> request)
        {
            var response = await _apiClient.PostAsJsonAsync(ApiUrls.JourneyServiceUrl.GetBusJourneys, request);

            return await response.Content.ReadFromJsonAsync<ResponseBaseModel<List<BusJourneyResponseModel>>>();
        }
    }
}