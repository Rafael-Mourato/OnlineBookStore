using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OnlineBookStore.Models;
using System.Security.Policy;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly OnlineBookStoreDbContext _dbContext;

        public BooksController(OnlineBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        // GET: api/<ApiController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = _dbContext.Book.ToList();
            return Ok(books);
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var books = _dbContext.Book.FirstOrDefault(b => b.Id == id);
            if (books == null)
            {
               return NotFound();
            }

            return Ok(books);
        }

        // POST api/<ApiController>
        [HttpPost]
        public ActionResult Post([FromBody] OrderJsonModel orderJson)
        {
            if (orderJson == null)
            {
                return BadRequest();
            }

            var book = _dbContext.Book.FirstOrDefault(b => b.Id == orderJson.BookId);

            var order = new Order()
            {
                BookId = orderJson.BookId,
                Username = orderJson.Username,
                Address = orderJson.Address,
                Price = book.Price
            };

            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }
    }
}

public class OrderJsonModel
{
    public int BookId { get; set; }
    public string Username { get; set; }
    public string Address { get; set; }
}

//curl -X POST https://localhost:44319/api/books -H "Content-Type: application/json" -d "{\"BookId\": 1, \"Username\": \"Rafael\", \"Address\": \"Praca Dr. Joao Tavares Lt3 2D, Portalegre 7300-025\"}"
