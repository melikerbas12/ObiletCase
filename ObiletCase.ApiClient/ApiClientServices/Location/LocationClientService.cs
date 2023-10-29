using System.Net.Http.Json;
using ObiletCase.Core.Models;

namespace ObiletCase.ApiClient.ApiClientServices
{
    public class LocationClientService : ILocationClientService
    {
        private readonly HttpClient _apiClient;
        public LocationClientService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<ResponseBaseModel<List<BusLocationResponseModel>>> GetBusLocation(RequestBaseModel<string> request)
        {
            var response = await _apiClient.PostAsJsonAsync(ApiUrls.LocationServiceUrl.GetBusLocations,request);

            return await response.Content.ReadFromJsonAsync<ResponseBaseModel<List<BusLocationResponseModel>>>();
        }
    }
}