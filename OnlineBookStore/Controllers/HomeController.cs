using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Models;
using OnlineBookStore.ViewModels;
using System.Diagnostics;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineBookStoreDbContext _dbcontext;
        private readonly ILogger<HomeController> _logger;
        private List<Book> books = new List<Book>();

        public HomeController(OnlineBookStoreDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbcontext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            books = _dbcontext.Book.AsQueryable().ToList();

            var viewModel = new IndexViewModel()
            {
                Books = books
            };
            return View(viewModel);
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
