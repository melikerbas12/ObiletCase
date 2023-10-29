using Microsoft.Extensions.Options;
using ObiletCase.Core.Settings;

namespace ObiletCase.UI.Handlers
{
    public class TokenHttpRequestDelegatingHandler : DelegatingHandler
    {
        private readonly ApiSetting _apiSetting;

        public TokenHttpRequestDelegatingHandler(IOptions<ApiSetting> apiSetting)
        {
            _apiSetting = apiSetting.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization", $"Basic {_apiSetting.Token}");
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}