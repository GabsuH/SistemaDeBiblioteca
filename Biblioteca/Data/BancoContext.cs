using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }
    

    public DbSet<UsuarioModel> Usuarios {  get; set; }
    public DbSet<LivrosModel> Livros { get; set; }
    }
}
