using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ObiletCase.Business.Services;
using ObiletCase.Core;
using ObiletCase.Core.Models;
using ObiletCase.Core.Settings;
using ObiletCase.UI.ViewModels;

namespace ObiletCase.Controllers;
public class JourneyController : Controller
{
    private readonly ILocationService _locationService;
    private readonly IJourneyService _journeyService;
    private readonly IRedisContext _redisContext;
    private readonly CacheItemSettings _cacheItemSetting;

    public JourneyController(ILocationService locationService, IJourneyService journeyService, IRedisContext redisContext, IOptions<CacheItemSettings> cacheItemSettings)
    {
        _locationService = locationService;
        _journeyService = journeyService;
        _redisContext = redisContext;
        _cacheItemSetting = cacheItemSettings.Value;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _locationService.GetBusLocations(string.Empty);
        if (result.Success)
        {
            BusLocationViewModel busLocationViewModel = new()
            {
                Date = DateTime.Now.AddDays(1),
                BusLocations = result.Data
            };
            return View(busLocationViewModel);
        }
        ViewBag["ErrorMessage"] = result.Message;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(BusLocationViewModel model)
    {
        var result = await _locationService.GetBusLocations(string.Empty);
        if (result.Success)
        {
            BusLocationViewModel busLocationViewModel = new()
            {
                Date = model.Date,
                OriginId = model.OriginId,
                DestinationId = model.DestinationId,
                BusLocations = result.Data
            };
            return View(busLocationViewModel);
        }
        ViewBag["ErrorMessage"] = result.Message;

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> BusLocationListSearch(string search)
    {
        var result = await _locationService.GetBusLocations(search);
        if (result.Success)
            return Json(result.Data);
        else
            return Json(new { error = result.Message });
    }

    [HttpPost]
    public async Task<IActionResult> BusJourney(int originId, int destinationId, DateTime date)
    {
        BusJourneyRequestModel requestModel = new()
        {
            OriginId = originId,
            DestinationId = destinationId,
            DepartureDate = date.ToString("yyyy-MM-dd")
        };

        var result = await _journeyService.GetBusJourneys(requestModel);
        if (result.Success)
        {
            BusJourneyViewModel busJourneyViewModel = new()
            {
                OriginLocation = await _redisContext.GetAsync<string>(_cacheItemSetting.Db,  string.Format("{0}:{1}", "LocationId", originId)),
                DestinationLocation =  await _redisContext.GetAsync<string>(_cacheItemSetting.Db,  string.Format("{0}:{1}", "LocationId", destinationId)),
                Date = date,
                BusJourneys = result.Data
            };
            return View(busJourneyViewModel);
        }

        ViewBag["ErrorMessage"] = result.Message;
        return View();
    }
}
