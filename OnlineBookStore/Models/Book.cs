using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; }
        [Key]
        public string ISBN { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
