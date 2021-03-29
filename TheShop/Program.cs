using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using TheShop.Core.Services.LogService;
using TheShop.Core.Services.ShopServices;
using TheShop.Core.Services.SupplierService;
using TheShop.DataAccess.Infrastructure.Shop;
using TheShop.Shared.Models;

namespace TheShop
{
	internal class Program
	{
		
		private static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder();
			BuildConfig(builder);

			AppStart();
		}
		static async void AppStart() {

			//TODO: these config methods should be in seperate class, something like Startup.cs in ASP.NetCore
			var host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					//core
					services.AddSingleton<IShopService, ShopService>();
					services.AddSingleton<ILogService, LogService>();
					services.AddSingleton<ISupplierService, SupplierService>();
					
					//repo
					services.AddSingleton<IShopRepository, ShopRepository>();
				})
				.Build();//TODO: we could use serilog here
			var shopService = ActivatorUtilities.GetServiceOrCreateInstance<IShopService>(host.Services);

			try
			{
				//order and sell
				await shopService.OrderArticle(1, 20);
				await shopService.SellArticle(10,
					new ArticleModel
					{
						Name_of_article = "my new article",
						ArticlePrice = 12,
					});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				//print article on console
				var article = await shopService.GetById(1);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = await shopService.GetById(12);
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