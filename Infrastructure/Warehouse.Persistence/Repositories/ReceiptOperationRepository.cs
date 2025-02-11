using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces.Repositories;

namespace Warehouse.Persistence.Repositories
{
	public class ReceiptOperationRepository : BaseRepository<ReceiptOperation>, IReceiptOperationRepository
	{
		public ReceiptOperationRepository(WarehouseContext context) : base(context)
		{
		}
	}
}
