using ObiletCase.Core.Models;

namespace ObiletCase.ApiClient.ApiClientServices
{
    public interface ISessionClientService
    {
        Task<ResponseBaseModel<SessionResponseModel>> GetSession();
    }
}