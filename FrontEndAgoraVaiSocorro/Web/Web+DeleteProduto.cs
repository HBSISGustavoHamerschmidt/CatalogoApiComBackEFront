using System;
using System.Net.Http;

namespace FrontEnd.Web
{
    public partial class Web
    {
		public static async void DeleteProduto()
        {
            Console.WriteLine($"\n\n{"".PadRight(52, '-')}\n  Excluindo produto...\n");

            Console.Write("  Insira o Id do produto a ser deletado:  ");
            var idDelete = Console.ReadLine();

            var client = new HttpClient {BaseAddress = new Uri($"{Url}/{idDelete}")};
            var responseMessage = await client.DeleteAsync(client.BaseAddress);

            Console.WriteLine(responseMessage.IsSuccessStatusCode
                ? "\n  Produto excluído com sucesso!"
                : $"\n  Falha ao excluir o produto: {responseMessage.StatusCode}");

            Console.ReadKey();
        }
	}
}