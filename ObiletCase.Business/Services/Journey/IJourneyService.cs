using ObiletCase.Core.Models;
using ObiletCase.Core.Utilities.Results;

namespace ObiletCase.Business.Services
{
    public interface IJourneyService
    {
          Task<IDataResult<List<BusJourneyResponseModel>>> GetBusJourneys(BusJourneyRequestModel request);
    }
}