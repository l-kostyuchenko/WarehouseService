using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Warehouse.Persistence.Extensions
{
	public static class MigrateExtensions
	{
		public static void UseDBMigration(this IServiceProvider provider)
		{
			using var scope = provider.CreateScope();
			var dbcontext = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
			dbcontext.Database.Migrate();
		}
	}
}
