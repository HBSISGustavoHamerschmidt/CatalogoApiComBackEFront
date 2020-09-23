using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CatalogoApi.Models;
using Newtonsoft.Json;

namespace FrontEnd.Web
{
    public partial class Web
    {
        public static string Url = "https://localhost:44330/api/produtos";

        public static async void GetAllProdutos(int idDaCategoria)
        {
            var response = await new HttpClient().GetAsync($"{Url}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var produtos = JsonConvert.DeserializeObject<List<Produto>>(jsonResponse);

                Console.Clear();
                Console.WriteLine("Id: | Nome:                          | Descricao:                                         | Estoque: | Preço:  ");
                foreach (var produto in produtos.Where(produto => produto.CategoriaId == idDaCategoria))
                {
                    Console.WriteLine($"{produto.ProdutoId, -3} | {produto.Nome, -30} | {produto.Descricao, -50} | {produto.Estoque, -8} | {produto.Preco, -8}");
                }
            }
            else
                Console.WriteLine($"Ocorreu algum erro: {response.StatusCode}");

            Console.WriteLine("\n\nPressione qualquer tecla para retornar ao menu principal.");
            Console.ReadKey();
        }
	}
}