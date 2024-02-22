using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Text_Splitter_App.Models;

namespace Text_Splitter_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextViewModel model)
        {
            return View(model);
        }
        public IActionResult Split(TextViewModel model)
        {
            var splittextArray = model
                .Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            model.SolitText = string.Join(Environment.NewLine, splittextArray);

            return RedirectToAction("Index",model);
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