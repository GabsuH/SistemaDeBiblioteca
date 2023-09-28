using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o CPF")]
        public int CPF { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a data de nascimento")]
        public DateTime DataDeNascimento { get; set; }
        [Required(ErrorMessage = "Digite o telefone")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }
    }
}
