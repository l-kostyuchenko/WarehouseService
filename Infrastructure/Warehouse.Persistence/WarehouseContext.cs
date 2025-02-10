using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Warehouse.Domain.Entities;

namespace Warehouse.Persistence
{
	public class WarehouseContext : DbContext
	{
		public DbSet<WarehouseItem> WarehouseItems { get; set; }
		public DbSet<BaseOperation> BaseOperations { get; set; }
		//public DbSet<ReceiptOperation> ReceiptOperations { get; set; }
		//public DbSet<WriteOffOperation> WriteOffOperations { get; set; }
		public DbSet<OperationItem> OperationItems { get; set; }

		public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<BaseOperation>().UseTphMappingStrategy();

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
