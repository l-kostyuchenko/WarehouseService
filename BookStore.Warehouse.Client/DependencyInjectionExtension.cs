using BookStore.Warehouse.Client.Interfaces;
using BookStore.Warehouse.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using System.Xml.Linq;

namespace BookStore.Warehouse.Client
{
	public static class DependencyInjectionExtension
	{
		static string serviceName = "Warehouse";

		public static void AddWarehouseClient(this IServiceCollection services, IConfigurationManager configuration)
		{
			var section = configuration?.GetSection(IntegrationServicesOptions.IntegationServiceKey);

			var opt = section.Get<IntegrationServicesOptions>();

			services.AddRefitClient<IWarehouseApi>()
				.ConfigureHttpClient(c =>
				c.BaseAddress = new Uri(opt.Services[serviceName].BaseAddress));

			services.AddOptions<IntegrationServicesOptions>().Configure(section.Bind);

			services.AddScoped<IWarehouseService, WarehouseService>();
		}
	}

	public class IntegrationServicesOptions
	{
		public const string IntegationServiceKey = nameof(IntegrationServicesOptions);
		public required IDictionary<string, IntegrationService> Services { get; set; }
	}
	public class IntegrationService
	{
		public required string BaseAddress { get; set; }
	}
}
