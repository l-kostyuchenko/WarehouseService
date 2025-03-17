using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Repositories;

namespace Warehouse.Persistence.Repositories
{
	public class WarehouseItemRepository : IWarehouseItemRepository
	{
		private readonly WarehouseContext _context;

		public WarehouseItemRepository(WarehouseContext context)
		{
			_context = context;
		}

		public async Task<List<WarehouseItem>> GetAllAsync(CancellationToken cancellationToken)
		{
			var entities = await _context.WarehouseItems
				.ToListAsync(cancellationToken);

			return entities;
		}

		public async Task<WarehouseItem> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			var entity = await _context.WarehouseItems
				.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

			return entity;
		}

		public async Task UpdateAsync(WarehouseItem entity, CancellationToken cancellationToken)
		{
			if (entity != null)
			{
				_context.WarehouseItems.Update(entity);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task<WarehouseItem> CreateAsync(WarehouseItem entity, CancellationToken cancellationToken)
		{
			_context.WarehouseItems.Add(entity);
			await _context.SaveChangesAsync(cancellationToken);
			return entity;
		}

		public async Task<WarehouseItem> GetByBookIdAsync(int id, CancellationToken cancellationToken)
		{
			var entity = await _context.WarehouseItems
				.FirstOrDefaultAsync(b => b.BookId == id, cancellationToken);

			return entity;
		}
	}
}
