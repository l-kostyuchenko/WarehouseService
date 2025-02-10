namespace Warehouse.Domain.Entities
{
	public class WarehouseItem : BaseEntity
	{
		public int BookId { get; set; } // ID книги из микросервиса "Книжный интернет-магазин"
		public int Quantity { get; set; } // Количество книг на складе
	}
}
