using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models;
using OnlineBookStore.ViewModels;
using System.Diagnostics;
using System.Security.Policy;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineBookStoreDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private List<Book> books = new List<Book>();

        public HomeController(OnlineBookStoreDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            books = _dbContext.Book.AsQueryable().Where(b => b.IsAvailable == true).ToList();

            var viewModel = new IndexViewModel()
            {
                Books = books
            };
            return View(viewModel);
        }

        public IActionResult BookDetails(int id = default)
        {
            var book = _dbContext.Book.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Book Page";

            return View("BookDetails", book);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Adicionar Livro";
            ViewData["Button"] = "Guardar";

            PopulateDropdowns();

            return View("CreateEdit", new Book());
        }


        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                books.Add(book);
                _dbContext.Book.Add(book);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            

            PopulateDropdowns();

            return View("CreateEdit", book);
        }

        public IActionResult Edit(int id = default)
        {
            ViewData["Title"] = "Editar Livro";

            var book = _dbContext.Book.FirstOrDefault(s => s.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            PopulateDropdowns();

            return View("CreateEdit", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                var existBook = _dbContext.Book.FirstOrDefault(s => s.Id == book.Id);
                if (existBook != null)
                {
                    existBook.Title = book.Title;
                    existBook.ISBN = book.ISBN;
                    existBook.Publisher = book.Publisher;
                    existBook.Author = book.Author;
                    existBook.Synopsis = book.Synopsis;
                    existBook.Image = book.Image;
                    existBook.Year = book.Year;
                    existBook.Pages = book.Pages;
                    existBook.Language = book.Language;
                    existBook.Genre = book.Genre;
                    existBook.Price = book.Price;
                    existBook.IsAvailable = book.IsAvailable;
                }

                if (existBook != null)
                {
                    var result = _dbContext.Book.Update(existBook);
                    _dbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index)); //CHANGE!!!!
            }

            PopulateDropdowns();

            return View("CreateEdit");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private void PopulateDropdowns()
        {
            ViewBag.LanguageOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Português", Text = "Português" },
                new SelectListItem { Value = "Inglês", Text = "Inglês" },
                new SelectListItem { Value = "Espanhol", Text = "Espanhol" },
                new SelectListItem { Value = "Francês", Text = "Francês" },
                new SelectListItem { Value = "Alemão", Text = "Alemão" },
            };

            ViewBag.GenreOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Economia, Finanças e Contabilidade", Text = "Economia, Finanças e Contabilidade"},
                new SelectListItem { Value = "Ficção", Text = "Ficção" },
                new SelectListItem { Value = "Romance", Text = "Romance" },
                new SelectListItem { Value = "Fantasia", Text = "Fantasia" },
                new SelectListItem { Value = "Mistério", Text = "Mistério" },
                new SelectListItem { Value = "Biografia", Text = "Biografia" },
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
