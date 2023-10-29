using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using ObiletCase.Core.Models;
using ObiletCase.Core.Settings;

namespace ObiletCase.ApiClient.ApiClientServices
{
    public class SessionClientService : ISessionClientService
    {
        private readonly HttpClient _apiClient;
        private readonly SessionSetting _sessionSetting;
        private readonly ConnectionSetting _connectionSetting;
        private readonly BrowserSetting _browserSetting;
        public SessionClientService(HttpClient apiClient, IOptions<SessionSetting> sessionSetting)
        {
            _apiClient = apiClient;
            _sessionSetting = sessionSetting.Value;
            _connectionSetting = sessionSetting.Value.Connection;
            _browserSetting = sessionSetting.Value.Browser;
        }
        public async Task<ResponseBaseModel<SessionResponseModel>> GetSession()
        {
            var request = new SessionRequestModel()
            {
                Type = _sessionSetting.Type,
                Connection = new Connection() { IpAddress = _connectionSetting.IpAddress, Port = _connectionSetting.Port },
                Browser = new Browser() { Name = _browserSetting.Name, Version = _browserSetting.Version }
            };

            var response = await _apiClient.PostAsJsonAsync(ApiUrls.ClientServiceUrl.GetSession, request);
            return await response.Content.ReadFromJsonAsync<ResponseBaseModel<SessionResponseModel>>();
        }
    }
}