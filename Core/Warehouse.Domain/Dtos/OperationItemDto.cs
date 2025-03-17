namespace Warehouse.Domain.Dtos
{
	public class OperationItemDto	
	{
		public int OperationId { get; set; }
		
		public int BookId { get; set; }
		
		public int Count { get; set; }
		public decimal Price { get; set; }
	}
}
