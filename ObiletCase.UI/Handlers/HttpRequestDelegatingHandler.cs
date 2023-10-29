using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ObiletCase.ApiClient.ApiClientServices;
using ObiletCase.Core.Settings;
using ObiletCase.UI.Helpers;

namespace ObiletCase.UI.Handlers
{
    public class HttpRequestDelegatingHandler : DelegatingHandler
    {
        private readonly ApiSetting _apiSetting;
        private readonly ISessionClientService _sessionClientService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpRequestDelegatingHandler(IOptions<ApiSetting> apiSetting, ISessionClientService sessionClientService, IHttpContextAccessor httpContextAccessor)
        {
            _apiSetting = apiSetting.Value;
            _sessionClientService = sessionClientService;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var existSession = _httpContextAccessor.HttpContext!.Session;

            var deviceId = SessionHelper.Get(existSession, "DeviceId");
            var sessionId = SessionHelper.Get(existSession, "SessionId");

            if (string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(sessionId))
            {
                var session = await _sessionClientService.GetSession();
                deviceId = session.Data.DeviceId.ToString();
                sessionId = session.Data.SessionId.ToString();

                SessionHelper.Set(existSession, "DeviceId", deviceId);
                SessionHelper.Set(existSession, "SessionId", sessionId);
            }
            string content = await request.Content!.ReadAsStringAsync();

            JObject jsonContent = JObject.Parse(content);

            JObject deviceSession = (JObject)jsonContent["device-session"]!;

            deviceSession["session-id"] = sessionId;
            deviceSession["device-id"] = deviceId;

            jsonContent["device-session"] = deviceSession;

            string updatedContent = jsonContent.ToString();

            request.Content = new StringContent(updatedContent, Encoding.UTF8, "application/json");
            request.Headers.Add("Authorization", $"Basic {_apiSetting.Token}");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}