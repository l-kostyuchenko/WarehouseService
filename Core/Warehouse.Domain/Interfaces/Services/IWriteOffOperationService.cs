using BookStore.Warehouse.Client.Dtos;
using Warehouse.Domain.Dtos;

namespace Warehouse.Domain.Interfaces.Services
{
	public interface IWriteOffOperationService
	{
		Task<WriteOffOperationDto> CreateAsync(WriteOffOperationDto createWriteOffOperationDto, CancellationToken cancellationToken);
		Task DeleteAsync(int id, CancellationToken cancellationToken);
		Task<WriteOffOperationDto> GetByIdAsync(int id, CancellationToken cancellationToken);
		Task UpdateAsync(WriteOffOperationDto updateWriteOffOperationDto, CancellationToken cancellationToken);

		Task ProcessOrder(OrderDto order);
	}
}