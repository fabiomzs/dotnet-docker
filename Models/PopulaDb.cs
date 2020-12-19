using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace mvc1.Models
{
    public static class PopulaDb
    {
        public static void IncluiDadosDb(IApplicationBuilder app)
        {
            IncluiDadosDb(app.ApplicationServices.GetRequiredService<AppDbContext>());
        }

        public static void IncluiDadosDb(AppDbContext context)
        {
            context.Database.Migrate();
            if (!context.Produtos.Any())
            {
                System.Console.WriteLine("Criando dados...");

                context.Produtos.AddRange(
                    new Produto { ProdutoId = 10, Nome = "Luvas de goleiro", Categoria = "Futebol", Preco = 25M },
                    new Produto { ProdutoId = 20, Nome = "Bola de basquete", Categoria = "Basquete", Preco = 48.95M },
                    new Produto { ProdutoId = 40, Nome = "Bola de futebol", Categoria = "Futebol", Preco = 19.50M },
                    new Produto { ProdutoId = 50, Nome = "Meias grandes", Categoria = "Futebol", Preco = 50M },
                    new Produto { ProdutoId = 60, Nome = "Cesta para quadra", Categoria = "Basquete", Preco = 29.95M }
                    );

                context.SaveChanges();
            } else
            {
                System.Console.WriteLine("Dados já existem...");
            }
        }
    }
}