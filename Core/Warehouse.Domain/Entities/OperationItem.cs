namespace Warehouse.Domain.Entities
{
	public class OperationItem : BaseEntity
	{
		public int BaseOperationId { get; set; }
		public BaseOperation BaseOperation { get; set; }

		public int WarehouseItemId { get; set; }
		public WarehouseItem WarehouseItem { get; set; }

		public int Count { get; set; }
		public decimal Price { get; set; }
	}
}
