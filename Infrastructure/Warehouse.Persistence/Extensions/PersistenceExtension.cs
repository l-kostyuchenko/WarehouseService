using Warehouse.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Domain.Repositories;

namespace Warehouse.Persistence.Extensions
{
	public static class PersistenceExtension
	{
		public static void AddPersistence(this IServiceCollection services)
		{
			services.AddScoped<IWarehouseItemRepository, WarehouseItemRepository>();
			//services.AddScoped<ICategoryRepository, CategoryRepository>();
			//services.AddScoped<IOrderRepository, OrderRepository>();
		}
	}
}
