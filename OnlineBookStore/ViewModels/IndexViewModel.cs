using OnlineBookStore.Models;

namespace OnlineBookStore.ViewModels
{
    public class IndexViewModel
    {
        public Order Order { get; set; }
        public Book Book { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Order> Orders { get; set; } = new List<Order>();

    }

    public class UpdateOrderStatusViewModel
    {
        public int Id { get; set;  }
        public bool Status { get; set; }
    }
}
