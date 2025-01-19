using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models;
using OnlineBookStore.ViewModels;
using System.Diagnostics;
using System.Dynamic;
using System.Security.Policy;

namespace OnlineBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineBookStoreDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private List<Book> books = new List<Book>();
        private List<Order> orders = new List<Order>();

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
            ViewData["Type"] = "Create";
            ViewData["Button"] = "Guardar";

            PopulateDropdowns();

            return View("CreateEdit", new Book());
        }


        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = 0;
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
            ViewData["Type"] = "Edit";

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
            if (ModelState.IsValid)
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

                    _dbContext.Book.Update(existBook);
                    _dbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(BackOffice));
            }

            PopulateDropdowns();

            return View("CreateEdit", book);
        }

        public IActionResult Delete(int id = default)
        {
            var book = _dbContext.Book.FirstOrDefault(s => s.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            _dbContext.Book.Remove(book);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(BackOffice));
        }

        public IActionResult OrderRegister(int id = default)
        {
            var book = _dbContext.Book.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            var viewModel = new IndexViewModel()
            {
                Book = book,
                Order = new Order { BookId = book.Id } // Inicializa o Order com o BookId
            };
            return View("OrderRegister", viewModel);
        }

        [HttpPost]
        public IActionResult OrderRegister(Order order)
        {
            var book = _dbContext.Book.FirstOrDefault(b => b.Id == order.BookId);
            if (book == null)
            {
                ModelState.AddModelError("BookId", "Invalid book ID.");
                var viewModel = new IndexViewModel
                {
                    Order = order,
                    Book = null
                };
                return View("OrderRegister", viewModel);
            }

            order.Price = book.Price;

            orders.Add(order);
            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult BackOffice()
        {
            books = _dbContext.Book.AsQueryable().ToList();
            var viewModel = new IndexViewModel()
            {
                Books = books
            };
            return View(viewModel);
        }

        public IActionResult BackOfficeOrdersPage()
        {
            orders = _dbContext.Order.AsQueryable().ToList();
            var viewModel = new IndexViewModel()
            {
                Orders = orders
            };
            return View(viewModel);
        }

        public IActionResult About()
        {
            return View("About");
        }

        private void PopulateDropdowns()
        {
            ViewBag.LanguageOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-Selecione um idioma-" },
                new SelectListItem { Value = "Português", Text = "Português" },
                new SelectListItem { Value = "Inglês", Text = "Inglês" },
                new SelectListItem { Value = "Espanhol", Text = "Espanhol" },
                new SelectListItem { Value = "Francês", Text = "Francês" },
                new SelectListItem { Value = "Alemão", Text = "Alemão" },
            };

            ViewBag.GenreOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-Selecione um género-" },
                new SelectListItem { Value = "Economia, Finanças e Contabilidade", Text = "Economia, Finanças e Contabilidade"},
                new SelectListItem { Value = "Ficção", Text = "Ficção" },
                new SelectListItem { Value = "Romance", Text = "Romance" },
                new SelectListItem { Value = "Fantasia", Text = "Fantasia" },
                new SelectListItem { Value = "Infantil", Text = "Infantil" },
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
