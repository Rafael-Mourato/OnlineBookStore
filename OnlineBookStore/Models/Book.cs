using System.ComponentModel.DataAnnotations;


namespace OnlineBookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Deve conter no máximo 255 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        public string Author { get; set; } = string.Empty;

        public string Synopsis { get; set; } = string.Empty;

        [MaxLength(13, ErrorMessage = "Deve conter exatamente 13 caracteres"), MinLength(13, ErrorMessage = "Deve conter exatamente 13 caracteres")]
        public int ISBN { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        public string Publisher { get; set; } = string.Empty;

        [Required]
        [MaxLength(4, ErrorMessage = "Introduza um ano válido"), MinLength(4, ErrorMessage = "Introduza um ano válido")]
        public int Year { get; set; }

        public int Pages { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Deve conter no máximo 50 caracteres"), MinLength(4, ErrorMessage = "Deve conter no mínimo 4 caracteres")]
        public string Language { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "Deve conter no máximo 50 caracteres"), MinLength(5, ErrorMessage = "Deve conter no mínimo 5 caracteres")]
        public string Genre { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = false;
    }
}
