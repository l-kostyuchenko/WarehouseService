using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Domain.Entities
{
	public abstract class BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	}
}
