using Biblioteca.Data;
using Biblioteca.Models;
using System.Linq;
using System.Collections.Generic;

namespace Biblioteca.Repositorio
{
    public class LivrosPorUsuarioRepositorio : ILivrosPorUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public LivrosPorUsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<LivrosPorUsuarioModel> BuscarTodos()
        {
            return _bancoContext.LivrosPorUsuario.ToList();
        }

        public LivrosPorUsuarioModel Adicionar(LivrosPorUsuarioModel livrosPorUsuario)
        {
            _bancoContext.LivrosPorUsuario.Add(livrosPorUsuario);
            _bancoContext.SaveChanges();
            return livrosPorUsuario;
        }

    }
}
