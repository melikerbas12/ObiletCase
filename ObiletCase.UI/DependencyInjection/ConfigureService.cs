using System.Net.Security;
using ObiletCase.ApiClient.ApiClientServices;
using ObiletCase.Business.Services;
using ObiletCase.Business.Utilities;
using ObiletCase.Core;
using ObiletCase.Core.Settings;
using ObiletCase.UI.Handlers;
using Polly;
using Polly.Extensions.Http;

namespace ObiletCase.UI.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddTransient<HttpRequestDelegatingHandler>();
            services.AddTransient<TokenHttpRequestDelegatingHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<IJourneyClientService, JourneyClientService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["ApiSettings:ApiUrl"]!);
            })
            .ConfigureHttpClient((c) =>
                  new HttpClientHandler
                  {
                      ServerCertificateCustomValidationCallback = (sender, cert, chain,
                      sslPolicyErrors) =>
                      {
                          return sslPolicyErrors == SslPolicyErrors.None;
                      }
                  })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy())
                .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(50)))
                .AddHttpMessageHandler<HttpRequestDelegatingHandler>();

            services.AddHttpClient<ILocationClientService, LocationClientService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["ApiSettings:ApiUrl"]!);
            })
            .ConfigureHttpClient((c) =>
                 new HttpClientHandler
                 {
                     ServerCertificateCustomValidationCallback = (sender, cert, chain,
                     sslPolicyErrors) =>
                     {
                         return sslPolicyErrors == SslPolicyErrors.None;
                     }
                 })
               .SetHandlerLifetime(TimeSpan.FromMinutes(5))
               .AddPolicyHandler(GetRetryPolicy())
               .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(50)))
               .AddHttpMessageHandler<HttpRequestDelegatingHandler>();

            services.AddHttpClient<ISessionClientService, SessionClientService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["ApiSettings:ApiUrl"]!);
            })
            .ConfigureHttpClient((c) =>
                new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain,
                    sslPolicyErrors) =>
                    {
                        return sslPolicyErrors == SslPolicyErrors.None;
                    }
                })
               .SetHandlerLifetime(TimeSpan.FromMinutes(5))
               .AddPolicyHandler(GetRetryPolicy())
               .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(50)))
               .AddHttpMessageHandler<TokenHttpRequestDelegatingHandler>();

            return services;
        }

        public static IServiceCollection AddConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.Configure<CacheItemSettings>(configuration.GetSection("CacheItem"));
            #region Redis

            services.AddSingleton<IRedisContext>(sp =>
            {
                var redis = new RedisContext(configuration.GetSection("RedisConfig").Value);
                redis.Connect();
                return redis;
            });

            #endregion Redis

            services.AddRazorPages();
            services.AddScoped<IJourneyService, JourneyService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped(typeof(IGenerateRequestBaseModel<>), typeof(GenerateRequestBaseModel<>));

            services.Configure<ApiSetting>(configuration.GetSection("ApiSettings"));
            services.Configure<SessionSetting>(configuration.GetSection("SessionSettings"));

            return services;
        }
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                            retryAttempt)));
        }
    }
}