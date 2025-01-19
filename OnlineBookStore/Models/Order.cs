using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; } // Chave estrangeira explícita

        // Propriedade de navegação
        public Book Book { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(5, ErrorMessage = "Deve conter no mínimo 5 caracteres")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(350, ErrorMessage = "Deve conter no máximo 350 caracteres"), MinLength(50, ErrorMessage = "Deve conter no mínimo 50 caracteres")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public bool Status { get; set; } = false;
    }
}
