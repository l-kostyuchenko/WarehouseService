namespace Warehouse.Domain.Dtos
{
	public class OperationItemDto	
	{
		public int BaseOperationId { get; set; }
		
		public int WarehouseItemId { get; set; }
		
		public int Count { get; set; }
		public decimal Price { get; set; }
	}
}
