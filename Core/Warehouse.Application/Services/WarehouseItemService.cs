using Warehouse.Domain.Dtos;
using Warehouse.Domain.Repositories;
using Warehouse.Application.Mapper;
using Serilog;
using Warehouse.Domain.Services;
using System.Threading;
using Warehouse.Domain.Entities;

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

		public async Task ChangeCount(int id, int count, CancellationToken cancellationToken)
		{
			var warehouseItem = await _repository.GetByIdAsync(id, cancellationToken);
			if (warehouseItem == null)
				warehouseItem = await _repository.CreateAsync(new WarehouseItem
				{
					Id = id
				}, cancellationToken);

			warehouseItem.Quantity += count;
			if (warehouseItem.Quantity < 0)
				throw new InvalidOperationException("Количество меньше нуля");

			await _repository.UpdateAsync(warehouseItem, cancellationToken);
		}
	}
}
