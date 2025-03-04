using Warehouse.Domain.Dtos;
using Warehouse.Application.Mapper;
using Serilog;
using Warehouse.Domain.Interfaces.Repositories;
using Warehouse.Domain.Interfaces.Services;
using Warehouse.Domain.Services;
using BookStore.Warehouse.Client.Dtos;

namespace Warehouse.Application.Services
{
	public class WriteOffOperationService : IWriteOffOperationService
	{
		private readonly IWriteOffOperationRepository _repository;
		private readonly IWarehouseItemService _warehouseService;
		private readonly ILogger _logger;

		public WriteOffOperationService(IWriteOffOperationRepository repository, IWarehouseItemService warehouseService, ILogger logger)
		{
			_repository = repository;
			_warehouseService = warehouseService;
			_logger = logger.ForContext<WriteOffOperationService>();
		}

		public async Task<WriteOffOperationDto> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			var operation = await _repository.GetByIdAsync(id, cancellationToken);

			return WarehouseMapper.ToDto(operation);
		}

		public async Task<WriteOffOperationDto> CreateAsync(WriteOffOperationDto createWriteOffOperationDto, CancellationToken cancellationToken)
		{
			var operation = WarehouseMapper.ToEntity(createWriteOffOperationDto);

			await _repository.AddAsync(operation, cancellationToken);

			foreach (var item in operation.OperationItems)
			{
				await _warehouseService.ChangeCount(item.WarehouseItemId, -item.Count, cancellationToken);
			}

			_logger.Information("Создана операция Списание с ИД={id}", operation.Id);
			return WarehouseMapper.ToDto(operation);
		}

		public async Task UpdateAsync(WriteOffOperationDto updateWriteOffOperationDto, CancellationToken cancellationToken)
		{
			var operation = WarehouseMapper.ToEntity(updateWriteOffOperationDto);
			var oldOperation = await _repository.GetByIdAsync(operation.Id, cancellationToken);

			foreach (var item in operation.OperationItems)
			{
				var oldItem = oldOperation.OperationItems.Where(x => x.WarehouseItemId == item.WarehouseItemId).FirstOrDefault();
				await _warehouseService.ChangeCount(item.WarehouseItemId, -(item.Count - oldItem?.Count ?? 0), cancellationToken);
			}

			await _repository.UpdateAsync(operation, cancellationToken);
		}

		public async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			var operation = await _repository.GetByIdAsync(id, cancellationToken);

			await _repository.DeleteAsync(id, cancellationToken);

			foreach (var item in operation.OperationItems)
			{
				await _warehouseService.ChangeCount(item.WarehouseItemId, item.Count, cancellationToken);
			}

			_logger.Information("Удалена операция Списание с ИД={id}", id);
		}

		public async Task ProcessOrder(OrderDto order)
		{
			_logger.Information("Обработано Списание с ИД={id}", order.Id);

			await Task.CompletedTask; 
		}
	}
}
