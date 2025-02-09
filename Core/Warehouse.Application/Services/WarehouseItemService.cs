using Warehouse.Domain.Dtos;
using Warehouse.Domain.Repositories;
using Warehouse.Application.Mapper;
using Serilog;
using Warehouse.Domain.Services;

namespace Warehouse.Application.Services
{
	public class WarehouseItemService : IWarehouseItemService
	{
		private readonly IWarehouseItemRepository _repository;
		private readonly ILogger _logger;

		public WarehouseItemService(IWarehouseItemRepository repository, ILogger logger)
		{
			_repository = repository;
			_logger = logger.ForContext<WarehouseItemService>();
		}

		public async Task<WarehouseItemDto> GetWarehouseItemByIdAsync(int id, CancellationToken cancellationToken)
		{
			var warehouseItem = await _repository.GetByIdAsync(id, cancellationToken);

			return WarehouseMapper.ToDto(warehouseItem);
		}

		public async Task<WarehouseItemDto> CreateWarehouseItemAsync(CreateWarehouseItemDto createWarehouseItemDto, CancellationToken cancellationToken)
		{
			var warehouseItem = WarehouseMapper.ToEntity(createWarehouseItemDto);

			await _repository.CreateAsync(warehouseItem, cancellationToken);

			_logger.Information("Создана позиция с ИД={WarehouseItemId}", warehouseItem.Id);
			return WarehouseMapper.ToDto(warehouseItem);
		}

		public async Task UpdateWarehouseItemAsync(WarehouseItemDto updateWarehouseItemDto, CancellationToken cancellationToken)
		{
			var warehouseItem = WarehouseMapper.ToEntity(updateWarehouseItemDto);

			await _repository.UpdateAsync(warehouseItem, cancellationToken);
		}
	}
}
