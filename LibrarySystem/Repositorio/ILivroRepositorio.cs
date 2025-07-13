using LibrarySystem.Models;

namespace LibrarySystem.Repositorio
{
    public interface ILivroRepositorio
    {
        BookModel BuscarId(int id);
        List<BookModel> BuscarTodos();
        BookModel Adicionar(BookModel book);
        BookModel Atualizar(BookModel book);
        bool ApagarLivro(int id);
    }
}
