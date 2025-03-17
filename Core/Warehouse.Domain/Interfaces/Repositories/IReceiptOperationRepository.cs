using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Interfaces.Repositories
{
	public interface IReceiptOperationRepository : IBaseRepository<ReceiptOperation>
	{
		Task<ReceiptOperation> GetByIdIncludeOperationsAsync(int id, CancellationToken cancellationToken);
	}
}
