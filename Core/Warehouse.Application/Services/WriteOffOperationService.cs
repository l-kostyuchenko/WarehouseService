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
			var operation = await _repository.GetByIdIncludeOperationsAsync(id, cancellationToken);

			return WarehouseMapper.ToDto(operation);
		}

		public async Task<WriteOffOperationDto> CreateAsync(WriteOffOperationDto createWriteOffOperationDto, CancellationToken cancellationToken)
		{
			Domain.Entities.WriteOffOperation operation = WarehouseMapper.ToEntity(createWriteOffOperationDto);

			await _repository.AddAsync(operation, cancellationToken);

			foreach (var item in operation.OperationItems)
			{
				await _warehouseService.ChangeCount(item.BookId, -item.Count, cancellationToken);
			}

			_logger.Information("Создана операция Списание с ИД={id}", operation.Id);
			return WarehouseMapper.ToDto(operation);
		}

		public async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			var operation = await _repository.GetByIdIncludeOperationsAsync(id, cancellationToken);

			await _repository.DeleteAsync(id, cancellationToken);

			foreach (var item in operation.OperationItems)
			{
				await _warehouseService.ChangeCount(item.BookId, item.Count, cancellationToken);
			}

			_logger.Information("Удалена операция Списание с ИД={id}", id);
		}

		public async Task ProcessOrder(OrderDto orderDto)
		{
			WriteOffOperationDto createWriteOffOperationDto = OrderMapper.ToWriteOffOperationDto(orderDto);
			var res = await CreateAsync(createWriteOffOperationDto, CancellationToken.None);

			_logger.Information("Обработано Списание с ИД={id}", orderDto.Id);

			await Task.CompletedTask; 
		}
	}
}
