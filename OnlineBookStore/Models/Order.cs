using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string BookId { get; set; }
        public Book book { get; set; } //Foreign Key
        public string Username { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; } //Foreign Key

    }
}
