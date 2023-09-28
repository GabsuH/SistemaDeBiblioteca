using Biblioteca.Enum;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class LivrosPorUsuarioModel
    {
        public int Id { get; set; }

        public int LivroId { get; set; }
        public string LivroNome { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
    }
}
