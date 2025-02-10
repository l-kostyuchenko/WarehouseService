using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Interfaces.Repositories;

namespace Warehouse.Persistence.Repositories
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly WarehouseContext _dbContext;
		protected readonly DbSet<T> _dbSet;

		public BaseRepository(WarehouseContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
			_dbSet = _dbContext.Set<T>();
		}

		public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await _dbSet.FindAsync(id, cancellationToken);
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _dbSet.ToListAsync(cancellationToken);
		}

		public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
		{
			await _dbSet.AddAsync(entity, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken)
		{
			var entity = await GetByIdAsync(id, cancellationToken);
			if (entity != null)
			{
				_dbSet.Remove(entity);
				await _dbContext.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
