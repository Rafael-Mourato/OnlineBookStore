using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStore.Models
{
    public class Book
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Deve conter no máximo 255 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Author { get; set; }

        [Column(TypeName = "varchar(2000)")]
        public string Synopsis { get; set; }
        
        [Key]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Deve conter exatamente 13 caracteres")]
        [Column(TypeName = "int")]
        public string ISBN { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Deve conter no máximo 100 caracteres"), MinLength(3, ErrorMessage = "Deve conter no mínimo 3 caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Publisher { get; set; }
        
        [Required]
        [MaxLength(4, ErrorMessage = "Introduza um ano válido"), MinLength(4, ErrorMessage = "Introduza um ano válido")]
        [Column(TypeName = "year")]
        public int Year { get; set; }

        [Column(TypeName = "int")]
        public int Pages { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Deve conter no máximo 50 caracteres"), MinLength(4, ErrorMessage = "Deve conter no mínimo 4 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public string Language { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Deve conter no máximo 50 caracteres"), MinLength(5, ErrorMessage = "Deve conter no mínimo 5 caracteres")]
        public string Category { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAvailable { get; set; } = false;
    }
}
