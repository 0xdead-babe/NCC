using ClientSideState.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientSideState.Controllers
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

			CookieOptions options = new CookieOptions();
			options.Expires = DateTime.Now.AddDays(7); // cookie will be expired after seven days


			//Append to the response before returning the View	
			Response.Cookies.Append("role", "Admin", options);
			return View();
		}

		public IActionResult GetCookie()
		{
			var _cookie = Request.Cookies["role"];
			ViewData["role"] = _cookie;
			//cookie will be sent from the front end and using that cookie to populate the view and sending to frontEnd
			return View();
		}

		public IActionResult DeleteCookie()
		{
			Response.Cookies.Delete("role");
			return RedirectToAction("GetCookie");
		}

		public IActionResult GetDataFromQuery(int age, String name, string address)
		{
			return Content($"Age: {age}, Name: {name} Address: {address} ");
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