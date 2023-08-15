using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TempData.Models;

namespace TempData.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			TempData["ReadMe"] = "Hi! There";
			return View();
		}

		public IActionResult ReadData()
		{
			var _message = TempData["ReadMe"];
			//TempData.Keep(); // persist the temp data
			ViewData["Message"] = _message;
			return View();

			//refreshing the same view will not show Data next time
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
}