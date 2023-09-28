using Biblioteca.Data;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Repositorio;

namespace Biblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer("server=localhost;Database=DB_Biblioteca;uid=sa;pwd=123456;Integrated Security=SSPI;TrustServerCertificate=True"));
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ILivrosRepositorio, LivrosRepositorio>();
            builder.Services.AddScoped<ILivrosPorUsuarioRepositorio, LivrosPorUsuarioRepositorio>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}