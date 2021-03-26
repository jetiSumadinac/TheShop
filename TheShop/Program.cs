using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder();
			BuildConfig(builder);
			var host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{

				})
				.Build();



			var shopService = new ShopService();

			try
			{
				//order and sell
				shopService.OrderAndSellArticle(1, 20, 10);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				//print article on console
				var article = shopService.GetById(1);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = shopService.GetById(12);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			Console.ReadKey();
		}

		static void BuildConfig(IConfigurationBuilder builder) {
			builder.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true) //For diferent environments (dev, prod)
				.AddEnvironmentVariables();
		}
	}
}