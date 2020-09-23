using System;
using System.Net.Http;
using static FrontEnd.Web.Web;

namespace FrontEnd
{
    public class MainMenu
    {

        public static void Menu()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Seja bem vindo ao catalogo de produtos da loja Teodoro!");
                Console.WriteLine("Para consultar nossa lista de produtos, digite:");
                Console.WriteLine("1 -> Visualizar bebidas.");
                Console.WriteLine("2 -> Visualizar Lanches.");
                Console.WriteLine("3 -> Visualizar sobremesas.");
                Console.WriteLine("4 -> Adicionar novo produto.");
                Console.WriteLine("6 -> Deletar um produto.");
                Console.WriteLine("8 -> Encerrar aplicação.");

                try
                {
                    var resposta = Convert.ToInt32(Console.ReadLine());
                    if (resposta < 4 && resposta > 0)
                    {
                        GetAllProdutos(Convert.ToInt32(resposta));
                    }
                    else if (resposta == 4)
                    {
                        PostNewProduto();
                    }
                    else if (resposta == 6)
                    {
                        DeleteProduto();
                    }
                    else if (resposta == 8)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insira um número válido.");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.Clear();
                }
            }
        }
    }
}