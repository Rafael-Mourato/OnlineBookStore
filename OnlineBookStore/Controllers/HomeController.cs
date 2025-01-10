using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Models;
using System.Diagnostics;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineBookStoreDbContext _dbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(OnlineBookStoreDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbcontext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookDetails(int id = default)
        {
            ViewData["Title"] = "Book Page";
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
