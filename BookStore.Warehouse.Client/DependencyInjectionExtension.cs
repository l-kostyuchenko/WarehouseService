using BookStore.Warehouse.Client.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Xml.Linq;
//using Warehouse.Client.Interfaces;

namespace BookStore.Warehouse.Client
{
	public static class DependencyInjectionExtension
	{
		public static void AddWarehouseClient(this IServiceCollection services, IConfigurationManager configuration)
		{
			var integrServices = configuration?.GetSection("IntegrationServices");
			
			services.AddRefitClient<IWarehouseApi>().ConfigureHttpClient(c => 
				c.BaseAddress = new Uri(configuration.GetConnectionString("Warehouse")));

			
		}
	}

	public class Warehouse
	{
		public string BaseAddress { get; set; }
	}
}
