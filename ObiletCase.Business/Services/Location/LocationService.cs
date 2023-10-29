using System.Text.Json;
using Microsoft.Extensions.Options;
using ObiletCase.ApiClient.ApiClientServices;
using ObiletCase.Business.Utilities;
using ObiletCase.Core;
using ObiletCase.Core.Models;
using ObiletCase.Core.Settings;
using ObiletCase.Core.Utilities.Results;
using StackExchange.Redis;

namespace ObiletCase.Business.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRedisContext _redisContext;
        private readonly CacheItemSettings _cacheItemSetting;
        private readonly ILocationClientService _locationClientService;
        private readonly IGenerateRequestBaseModel<string> _generateRequestModel;
        public LocationService(ILocationClientService locationClientService, IGenerateRequestBaseModel<string> generateRequestModel, IRedisContext redisContext, IOptions<CacheItemSettings> cacheItemSettings)
        {
            _locationClientService = locationClientService;
            _generateRequestModel = generateRequestModel;
            _redisContext = redisContext;
            _cacheItemSetting = cacheItemSettings.Value;
        }
        public async Task<IDataResult<List<BusLocationResponseModel>>> GetBusLocations(string search)
        {
            var requestBaseModel = string.IsNullOrEmpty(search)
                    ? _generateRequestModel.GetRequestBaseModel(string.Empty)
                    : _generateRequestModel.GetRequestBaseModel(search);

            var response = await _locationClientService.GetBusLocation(requestBaseModel);

            if (response.Status == ResponseStatus.Success.ToString())
            {
                await _redisContext.RemoveRangeAsync(_cacheItemSetting.Db, "LocationId:*");

                await Task.WhenAll(response.Data!.Select(async item =>
                {
                    var prefix = string.Format("{0}:{1}", "LocationId", item.Id);
                    await _redisContext.SaveAsync(_cacheItemSetting.Db, prefix, item.Name, null);
                }));
                return new DataResult<List<BusLocationResponseModel>>(response.Data, true);
            }

            return new DataResult<List<BusLocationResponseModel>>(
                            new List<BusLocationResponseModel>(),
                            false,
                            response.Message?.ToString() ?? "Hata mesajı bulunamadı"
                        );
        }
    }
}