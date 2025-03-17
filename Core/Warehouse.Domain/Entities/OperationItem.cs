namespace Warehouse.Domain.Entities
{
	public class OperationItem : BaseEntity
	{
		public int OperationId { get; set; }
		public BaseOperation Operation { get; set; }

		public int BookId { get; set; }
		//public WarehouseItem WarehouseItem { get; set; }

		public int Count { get; set; }
		public decimal Price { get; set; }
	}
}
