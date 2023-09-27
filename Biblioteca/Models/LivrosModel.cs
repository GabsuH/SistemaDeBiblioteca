using Biblioteca.Enum;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class LivrosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do livro")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do autor")]
        public string Autor {  get; set; }
        [Required(ErrorMessage = "Digite a quantidade de paginas")]
        public int NumeroDePaginas { get; set; }
        [Required(ErrorMessage = "Digite a sinopse do livro")]
        public string Sinopse { get; set; }

        public StatusLivro Status { get; set; }
    }
}
