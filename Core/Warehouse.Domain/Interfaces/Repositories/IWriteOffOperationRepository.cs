using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Interfaces.Repositories
{
	public interface IWriteOffOperationRepository : IBaseRepository<WriteOffOperation>
	{
		Task<WriteOffOperation> GetByIdIncludeOperationsAsync(int id, CancellationToken cancellationToken);
	}
}
