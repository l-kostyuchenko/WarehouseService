using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Repositories
{
	public interface IWarehouseItemRepository
	{
		Task<WarehouseItem> CreateAsync(WarehouseItem entity, CancellationToken cancellationToken);
		Task<List<WarehouseItem>> GetAllAsync(CancellationToken cancellationToken);
		Task<WarehouseItem> GetByIdAsync(int id, CancellationToken cancellationToken);
		Task UpdateAsync(WarehouseItem entity, CancellationToken cancellationToken);
	}
}