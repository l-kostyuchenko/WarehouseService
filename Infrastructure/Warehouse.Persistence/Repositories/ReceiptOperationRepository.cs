using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces.Repositories;

namespace Warehouse.Persistence.Repositories
{
	public interface IReceiptOperationRepository : IBaseRepository<ReceiptOperation>
	{

	}

	public class ReceiptOperationRepository : BaseRepository<ReceiptOperation>, IReceiptOperationRepository
	{
		public ReceiptOperationRepository(WarehouseContext context) : base(context)
		{
		}
	}
}
