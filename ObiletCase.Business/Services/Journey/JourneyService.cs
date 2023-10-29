using ObiletCase.ApiClient.ApiClientServices;
using ObiletCase.Business.Utilities;
using ObiletCase.Core.Models;
using ObiletCase.Core.Utilities.Results;

namespace ObiletCase.Business.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyClientService _journeyClientService;
        private readonly IGenerateRequestBaseModel<BusJourneyRequestModel> _generateRequestModel;
        public JourneyService(IJourneyClientService journeyClientService, IGenerateRequestBaseModel<BusJourneyRequestModel> generateRequestModel)
        {
            _journeyClientService = journeyClientService;
            _generateRequestModel = generateRequestModel;
        }
        public async Task<IDataResult<List<BusJourneyResponseModel>>> GetBusJourneys(BusJourneyRequestModel request)
        {   
            var requestBaseModel = _generateRequestModel.GetRequestBaseModel(request);
            var response = await _journeyClientService.GetBusJourneys(requestBaseModel);

            return response.Status == ResponseStatus.Success.ToString()
                ? new DataResult<List<BusJourneyResponseModel>>(response.Data, true)
                : new DataResult<List<BusJourneyResponseModel>>(
                    new List<BusJourneyResponseModel>(),
                    false,
                    response.Message?.ToString() ?? "Hata mesajı bulunamadı"
                );
        }
    }
}