using Warehouse.Domain.Dtos;

namespace Warehouse.Domain.Interfaces.Services
{
	public interface IReceiptOperationService
	{
		Task<ReceiptOperationDto> CreateAsync(ReceiptOperationDto createReceiptOperationDto, CancellationToken cancellationToken);
		Task DeleteAsync(int id, CancellationToken cancellationToken);
		Task<ReceiptOperationDto> GetByIdAsync(int id, CancellationToken cancellationToken);
		Task UpdateAsync(ReceiptOperationDto updateReceiptOperationDto, CancellationToken cancellationToken);
	}
}