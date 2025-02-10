using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Interfaces.Repositories
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task AddAsync(T entity, CancellationToken cancellationToken);
		Task DeleteAsync(int id, CancellationToken cancellationToken);
		Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
		Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
		Task UpdateAsync(T entity, CancellationToken cancellationToken);
	}
}