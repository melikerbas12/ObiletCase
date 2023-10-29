using ObiletCase.Core.Models;

namespace ObiletCase.ApiClient.ApiClientServices
{
    public interface ILocationClientService
    {
        Task<ResponseBaseModel<List<BusLocationResponseModel>>> GetBusLocation(RequestBaseModel<string> request);
    }
}