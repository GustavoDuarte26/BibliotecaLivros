using LibrarySystem.Models;
using LibrarySystem.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;
        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }
        public IActionResult Index()
        {
            List<BookModel> books = _livroRepositorio.BuscarTodos();

            return View(books);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            BookModel book = _livroRepositorio.BuscarId(id);

            return View(book);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            BookModel book = _livroRepositorio.BuscarId(id);

            return View(book);
        }

        public IActionResult ApagarLivro(int id) 
        {
            _livroRepositorio.ApagarLivro(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(BookModel book)
        {
            if (ModelState.IsValid)
            {
                _livroRepositorio.Adicionar(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Alterar(BookModel book)
        {
            _livroRepositorio.Atualizar(book);

            return RedirectToAction("Index");
        }
    }
}
