using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevControl.Models;
using DevControl.Services;
using Microsoft.AspNetCore.Authorization;

namespace DevControl.Controllers;

[Authorize]
public class SatController : Controller
{
    private readonly ILogger<SatController> _logger;
    private readonly IData _data;
    public SatController(ILogger<SatController> logger, IData data)
    {
        _logger = logger;
        _data = data;
    }

    public IActionResult Index()
    {
        _data.AddUsuarioCentro(1010,10);
        return View("list", _data.GetTbUsuarios());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
