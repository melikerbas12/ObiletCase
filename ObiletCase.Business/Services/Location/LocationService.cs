using ObiletCase.ApiClient.ApiClientServices;
using ObiletCase.Business.Utilities;
using ObiletCase.Core.Models;
using ObiletCase.Core.Utilities.Results;

namespace ObiletCase.Business.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationClientService _locationClientService;
        private readonly IGenerateRequestBaseModel<string> _generateRequestModel;
        public LocationService(ILocationClientService locationClientService, IGenerateRequestBaseModel<string> generateRequestModel)
        {
            _locationClientService = locationClientService;
            _generateRequestModel = generateRequestModel;
        }
        public async Task<IDataResult<List<BusLocationResponseModel>>> GetBusLocations(string search)
        {
            var requestBaseModel = string.IsNullOrEmpty(search)
                    ? _generateRequestModel.GetRequestBaseModel(string.Empty)
                    : _generateRequestModel.GetRequestBaseModel(search);

            var response = await _locationClientService.GetBusLocation(requestBaseModel);

            return response.Status == ResponseStatus.Success.ToString()
                        ? new DataResult<List<BusLocationResponseModel>>(response.Data, true)
                        : new DataResult<List<BusLocationResponseModel>>(
                            new List<BusLocationResponseModel>(),
                            false,
                            response.Message?.ToString() ?? "Hata mesajı bulunamadı"
                        );
        }
    }
}