using LibrarySystem.DBContext;
using LibrarySystem.Models;

namespace LibrarySystem.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BancoDBContext _bancoDBContext;
        public LivroRepositorio(BancoDBContext bancoDBContext) 
        {
            _bancoDBContext = bancoDBContext;
        }

        public BookModel BuscarId(int id)
        {
            return _bancoDBContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public List<BookModel> BuscarTodos()
        {
            return _bancoDBContext.Books.ToList();
        }

        public BookModel Adicionar(BookModel book)
        {
            _bancoDBContext.Books.Add(book);
            _bancoDBContext.SaveChanges();

            return book;
        }

        public BookModel Atualizar(BookModel book)
        {
            BookModel bookBd = BuscarId(book.Id);

            if (bookBd == null)
                throw new Exception("Houve um erro na atualização do livro!");

            bookBd.NameBook = book.NameBook;
            bookBd.Year = book.Year;
            bookBd.Name = book.Name;

            _bancoDBContext.Books.Update(bookBd);
            _bancoDBContext.SaveChanges(); 
            
            return bookBd;
        }

        public bool ApagarLivro(int id)
        {
            BookModel bookBd = BuscarId(id);

            if (bookBd == null)
                throw new Exception("Houve um erro na exclusão do livro!");

            _bancoDBContext.Books.Remove(bookBd);
            _bancoDBContext.SaveChanges();

            return true;
        }
    }
}
