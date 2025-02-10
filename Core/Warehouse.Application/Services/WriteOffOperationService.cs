using Warehouse.Domain.Dtos;
using Warehouse.Domain.Repositories;
using Warehouse.Application.Mapper;
using Serilog;
using Warehouse.Domain.Services;
using Warehouse.Domain.Interfaces.Repositories;
using Warehouse.Domain.Interfaces.Services;

namespace Warehouse.Application.Services
{
	public class WriteOffOperationService : IWriteOffOperationService
	{
		private readonly IWriteOffOperationRepository _repository;
		private readonly ILogger _logger;

		public WriteOffOperationService(IWriteOffOperationRepository repository, ILogger logger)
		{
			_repository = repository;
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

			_logger.Information("Создана операция Списание с ИД={id}", operation.Id);
			return WarehouseMapper.ToDto(operation);
		}

		public async Task UpdateAsync(WriteOffOperationDto updateWriteOffOperationDto, CancellationToken cancellationToken)
		{
			var warehouseItem = WarehouseMapper.ToEntity(updateWriteOffOperationDto);

			await _repository.UpdateAsync(warehouseItem, cancellationToken);
		}

		public async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			await _repository.DeleteAsync(id, cancellationToken);
			_logger.Information("Удалена операция Списание с ИД={id}", id);
		}
	}
}
