using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Warehouse.Domain.Entities;

namespace Warehouse.Persistence
{
	public class WarehouseContext : DbContext
	{
		public DbSet<WarehouseItem> WarehouseItems { get; set; }
		

		public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
