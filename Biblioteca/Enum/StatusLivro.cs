using System.ComponentModel;

namespace Biblioteca.Enum
{
    public enum StatusLivro
    {
        [Description("Livro Disponível")]
        Disponivel = 1,
        [Description("Livro Indisponível")]
        Indisponivel = 2,
        [Description("Livro Alugado")]
        Alugado = 3,
    }
}
