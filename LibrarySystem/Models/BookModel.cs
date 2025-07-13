using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class BookModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do livro")]
        public string NameBook { get; set; }

        [Required(ErrorMessage = "Digite o ano do livro")]
        [AnoValidation]
        public int Year { get; set; }

        [Required(ErrorMessage = "Digite o Autor/Autora do livro")]
        public string Name { get; set; }
    }
}
