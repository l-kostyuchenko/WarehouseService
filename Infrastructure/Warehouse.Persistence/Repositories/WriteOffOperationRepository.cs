using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces.Repositories;

namespace Warehouse.Persistence.Repositories
{
	public class WriteOffOperationRepository : BaseRepository<WriteOffOperation>, IWriteOffOperationRepository
	{
		public WriteOffOperationRepository(WarehouseContext context) : base(context)
		{
		}

		public async Task<WriteOffOperation> GetByIdIncludeOperationsAsync(int id, CancellationToken cancellationToken)
		{
			return await _dbContext.WriteOffOperations.Include(x => x.OperationItems).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}
	}
}
