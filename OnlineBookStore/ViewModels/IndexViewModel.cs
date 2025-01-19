using OnlineBookStore.Models;

namespace OnlineBookStore.ViewModels
{
    public class IndexViewModel
    {
        public List<Book> Books { get; set; }
        public List<Order> Orders { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }

    }
}
