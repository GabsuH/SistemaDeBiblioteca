using Biblioteca.Models;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Biblioteca.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivrosRepositorio _livrosRepositorio;

        public LivrosController(ILivrosRepositorio livrosRepositorio)
        {
            _livrosRepositorio = livrosRepositorio;
        }

        public IActionResult Index()
        {
            List<LivrosModel> livros = _livrosRepositorio.BuscarTodos();
            return View(livros);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id) 
        {
            LivrosModel livros = _livrosRepositorio.ListarPorId(id);
            return View(livros);
        }

        public IActionResult ApagarConfirmacao(int  id)
        {
            LivrosModel livros = _livrosRepositorio.ListarPorId(id);
            return View(livros);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _livrosRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Livro apagada com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível apagar o Livro!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível apagar o Livro, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(LivrosModel livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livrosRepositorio.Adicionar(livro);
                    TempData["MensagemSucesso"] = "Livro criado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(livro);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível criar o livro, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(LivrosModel livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livrosRepositorio.Atualizar(livro);
                    TempData["MensagemSucesso"] = "Livro atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", livro);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}