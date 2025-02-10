using Warehouse.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Domain.Repositories;
using Warehouse.Domain.Interfaces.Repositories;

namespace Warehouse.Persistence.Extensions
{
	public static class PersistenceExtension
	{
		public static void AddPersistence(this IServiceCollection services)
		{
			services.AddScoped<IWarehouseItemRepository, WarehouseItemRepository>();
			services.AddScoped<IWriteOffOperationRepository, WriteOffOperationRepository>();
			services.AddScoped<IReceiptOperationRepository, ReceiptOperationRepository>();
		}
	}
}
