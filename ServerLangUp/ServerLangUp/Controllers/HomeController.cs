using Microsoft.AspNetCore.Mvc;
using ServerLangUp.Models;
using System.Diagnostics;

namespace ServerLangUp.Controllers
{
    public class HomeController : Controller
    {
        private TestContext context;
        public HomeController(TestContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
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