using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStore.Models
{
    public class Order
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Deve conter no máximo 50 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        [Column(TypeName = "int")]
        public string BookId { get; set; } = null!;

        [Required]
        public Book book { get; set; } = null!; //Foreign Key

        [Required]
        [MaxLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(5, ErrorMessage = "Deve conter no mínimo 5 caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(350, ErrorMessage = "Deve conter no máximo 350 caracteres"), MinLength(50, ErrorMessage = "Deve conter no mínimo 50 caracteres")]
        [Column(TypeName = "varchar(350)")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; } = false;
    }
}
