namespace Warehouse.Domain.Entities
{
	public class BaseOperation : BaseEntity
	{
		public DateTimeOffset OperationDate { get; set; }

		public List<OperationItem> OperationItems { get; set; } = new List<OperationItem>();
	}
}
