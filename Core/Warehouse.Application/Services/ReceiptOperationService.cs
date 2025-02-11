using Warehouse.Domain.Dtos;
using Warehouse.Application.Mapper;
using Serilog;
using Warehouse.Domain.Interfaces.Repositories;
using Warehouse.Domain.Interfaces.Services;

namespace Warehouse.Application.Services
{
	public class ReceiptOperationService : IReceiptOperationService
	{
		private readonly IReceiptOperationRepository _repository;
		private readonly ILogger _logger;

		public ReceiptOperationService(IReceiptOperationRepository repository, ILogger logger)
		{
			_repository = repository;
			_logger = logger.ForContext<ReceiptOperationService>();
		}

		public async Task<ReceiptOperationDto> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			var operation = await _repository.GetByIdAsync(id, cancellationToken);

			return WarehouseMapper.ToDto(operation);
		}

		public async Task<ReceiptOperationDto> CreateAsync(ReceiptOperationDto createReceiptOperationDto, CancellationToken cancellationToken)
		{
			var operation = WarehouseMapper.ToEntity(createReceiptOperationDto);

			await _repository.AddAsync(operation, cancellationToken);

			_logger.Information("Создана операция Списание с ИД={id}", operation.Id);
			return WarehouseMapper.ToDto(operation);
		}

		public async Task UpdateAsync(ReceiptOperationDto updateReceiptOperationDto, CancellationToken cancellationToken)
		{
			var warehouseItem = WarehouseMapper.ToEntity(updateReceiptOperationDto);

			await _repository.UpdateAsync(warehouseItem, cancellationToken);
		}

		public async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			await _repository.DeleteAsync(id, cancellationToken);
			_logger.Information("Удалена операция Списание с ИД={id}", id);
		}
	}
}
