using Biblioteca.Models;

namespace Biblioteca.Repositorio
{
    public interface ILivrosPorUsuarioRepositorio
    {
        List<LivrosPorUsuarioModel> BuscarTodos();
        LivrosPorUsuarioModel Adicionar(LivrosPorUsuarioModel livrosPorUsuario);
    }
}
