using System;
using System.Net.Http;
using System.Text;
using CatalogoApi.Models;
using Newtonsoft.Json;

namespace FrontEnd.Web
{
    public partial class Web
    {
        public static async void PostNewProduto()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(52, '-'));
            Console.WriteLine("\nAtente-se que nome e descrição devem estar preenchidos e \n" +
                              "só permitem caracteres alfabético sem acentuação e espaços.\n ");
            Console.WriteLine($"{"".PadRight(52, '-')}\nCriando novo produto...\n");

            var produto = new Produto();

            Console.Write("Nome do produto: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Descrição do produto: ");
            produto.Descricao = Console.ReadLine();

            Console.Write("Url da Imagem do produto: ");
            produto.ImageUrl = Console.ReadLine();

            Console.Write("Preço do produto: ");
            produto.Preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Estoque do produto: ");
            produto.Estoque = Convert.ToInt32(Console.ReadLine());

            Console.Write("Escolha a categoria do produto (1 -> Bebidas; 2 -> Lanches; 3 -> Sobremesas): ");
            produto.CategoriaId = Convert.ToInt32(Console.ReadLine());

            var content = new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8, "application/json");
            await new HttpClient().PostAsync($"{Url}", content);

            GetAllProdutos(produto.CategoriaId);
        }
	}
}