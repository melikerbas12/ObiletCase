using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObiletCase.Core.Models;

namespace ObiletCase.UI.Controllers;
public class HomeController : Controller
{
    public IActionResult Error(string messagesJson = "")
    {

        var errorMessages = JsonConvert.DeserializeObject<ErrorViewModel>(messagesJson);
        return View(errorMessages);
    }
}
