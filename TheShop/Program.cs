using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using TheShop.Core.Services.ShopServices;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			//TODO: these config methods should be in seperate class, something like Startup.cs in ASP.NetCore
			var builder = new ConfigurationBuilder();
			BuildConfig(builder);
			var host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					services.AddSingleton<IShopService, TheShop.Core.Services.ShopServices.ShopService>(); //TODO:
				})
				.Build();//TODO: we could use serilog here

			var svc = ActivatorUtilities.GetServiceOrCreateInstance<IShopService>(host.Services);

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