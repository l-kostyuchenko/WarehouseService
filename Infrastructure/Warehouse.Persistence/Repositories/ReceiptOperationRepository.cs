using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces.Repositories;

namespace Warehouse.Persistence.Repositories
{
	public class ReceiptOperationRepository : BaseRepository<ReceiptOperation>, IReceiptOperationRepository
	{
		public ReceiptOperationRepository(WarehouseContext context) : base(context)
		{
		}

		public async Task<ReceiptOperation> GetByIdIncludeOperationsAsync(int id, CancellationToken cancellationToken)
		{
			return await _dbContext.ReceiptOperations.Include(x=>x.OperationItems).FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
		}
	}
}
