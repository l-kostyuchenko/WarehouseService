using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.Services;
using Warehouse.Domain.Services;

namespace Warehouse.Application.Extensions
{
	public static class ApplicationExtension
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IWarehouseItemService, WarehouseItemService>();
			
			
		}
	}
}
