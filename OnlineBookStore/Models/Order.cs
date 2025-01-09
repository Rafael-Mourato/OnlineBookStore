using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Book book { get; set; } = null!; //Foreign Key

        [Required]
        [MaxLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(5, ErrorMessage = "Deve conter no mínimo 5 caracteres")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(350, ErrorMessage = "Deve conter no máximo 350 caracteres"), MinLength(50, ErrorMessage = "Deve conter no mínimo 50 caracteres")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public bool Status { get; set; } = false;
    }
}
