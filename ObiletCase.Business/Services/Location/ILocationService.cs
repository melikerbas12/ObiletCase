
using ObiletCase.Core.Models;
using ObiletCase.Core.Utilities.Results;

namespace ObiletCase.Business.Services
{
    public interface ILocationService
    {
         Task<IDataResult<List<BusLocationResponseModel>>> GetBusLocations(string search);
    }
}