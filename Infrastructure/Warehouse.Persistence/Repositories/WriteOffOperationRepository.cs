using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces.Repositories;

namespace Warehouse.Persistence.Repositories
{
	public class WriteOffOperationRepository : BaseRepository<WriteOffOperation>, IWriteOffOperationRepository
	{
		public WriteOffOperationRepository(WarehouseContext context) : base(context)
		{
		}		
	}
}
