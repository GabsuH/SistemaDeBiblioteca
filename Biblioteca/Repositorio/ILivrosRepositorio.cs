using Biblioteca.Models;

namespace Biblioteca.Repositorio
{
    public interface ILivrosRepositorio
    {
        LivrosModel ListarPorId(int id);
        List<LivrosModel> BuscarTodos();

        LivrosModel Adicionar(LivrosModel livros);
        LivrosModel Atualizar(LivrosModel livros);
        bool Apagar(int id);
    }
}
