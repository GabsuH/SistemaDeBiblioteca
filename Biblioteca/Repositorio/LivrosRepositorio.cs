using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Biblioteca.Repositorio
{
    public class LivrosRepositorio : ILivrosRepositorio
    {
        private readonly BancoContext _bancoContext;

        public LivrosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public LivrosModel ListarPorId(int id)
        {
            return _bancoContext.Livros.FirstOrDefault(x => x.Id == id);
        }

        public List<LivrosModel> BuscarTodos()
        {
            return _bancoContext.Livros.ToList();
        }

        public LivrosModel Adicionar(LivrosModel livros)
        {
            _bancoContext.Livros.Add(livros);
            _bancoContext.SaveChanges();
            return livros;
        }


        public LivrosModel Atualizar(LivrosModel livros)
        {
            LivrosModel livrosDB = ListarPorId(livros.Id);

            if(livrosDB == null)
            {
                throw new Exception("Houve um erro na atualização do Livro");
            }

            livrosDB.Nome = livros.Nome;
            livrosDB.Autor = livros.Autor;
            livrosDB.Sinopse = livros.Sinopse;
            livrosDB.NumeroDePaginas = livros.NumeroDePaginas;
            livrosDB.Status = livros.Status;

            _bancoContext.Livros.Update(livrosDB);
            _bancoContext.SaveChanges();

            return livrosDB;
        }

        public LivrosModel Reservar(LivrosModel livros, int id)
        {
            LivrosModel livrosDB = ListarPorId(livros.Id);

            if (livrosDB == null)
            {
                throw new Exception("Houve um erro na atualização do Livro");
            }
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            LivrosModel livrosDB = ListarPorId(id);

            if (livrosDB == null)
            {
                throw new Exception("Houve um erro na atualização da tarefa");
            }

            _bancoContext.Livros.Remove(livrosDB);
            _bancoContext.SaveChanges();

            return true;
        }

    }
}
