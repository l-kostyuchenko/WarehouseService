using Warehouse.Domain.Dtos;

namespace Warehouse.Domain.Services
{
	public interface IWarehouseItemService
	{
		Task<WarehouseItemDto> CreateWarehouseItemAsync(CreateWarehouseItemDto createWarehouseItemDto, CancellationToken cancellationToken);
		Task<WarehouseItemDto> GetWarehouseItemByIdAsync(int id, CancellationToken cancellationToken);
		Task UpdateWarehouseItemAsync(WarehouseItemDto updateWarehouseItemDto, CancellationToken cancellationToken);
		Task ChangeCount(int id, int count, CancellationToken cancellationToken);
	}
}