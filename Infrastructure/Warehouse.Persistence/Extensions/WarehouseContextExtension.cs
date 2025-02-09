using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Persistence.Extensions
{
	public static class WarehouseContextExtension
    {
        public static void AddContextExtension(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddDbContext<WarehouseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("WarehouseDatabase"))
                .UseSnakeCaseNamingConvention());
        }
    }
}
