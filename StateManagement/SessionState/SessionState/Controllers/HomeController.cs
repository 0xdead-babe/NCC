using Microsoft.AspNetCore.Mvc;
using SessionState.Models;
using System.Diagnostics;

namespace SessionState.Controllers
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
            //Store session related information on first request
            HttpContext.Session.SetString("Username", "Admin@abc.com");
            HttpContext.Session.SetString("Role", "Admin");

            return View();
        }


        public IActionResult MyRole()
        {
            var userName = HttpContext.Session.GetString("Username");
            var role = HttpContext.Session.GetString("Role");
            var _userAgent = HttpContext.Request.Headers["User-Agent"];

            UserInfo userInfo = new UserInfo() { Username = userName ?? "", Role = role ?? ""};
            ViewData["userAgent"] = _userAgent;
            return View(userInfo);
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