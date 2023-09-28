using Biblioteca.Models;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Biblioteca.Controllers
{
    public class LivrosPorUsuarioController : Controller
    {
        private readonly ILivrosPorUsuarioRepositorio _livrosPorUsuarioRepositorio;

        public LivrosPorUsuarioController(ILivrosPorUsuarioRepositorio livrosPorUsuarioRepositorio)
        {
            _livrosPorUsuarioRepositorio = livrosPorUsuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<LivrosPorUsuarioModel> livrosPorUsuario = _livrosPorUsuarioRepositorio.BuscarTodos();
            return View(livrosPorUsuario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(LivrosPorUsuarioModel livroPorUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livrosPorUsuarioRepositorio.Adicionar(livroPorUsuario);
                    TempData["MensagemSucesso"] = "Livro alugado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(livroPorUsuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível alugar o livro, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}