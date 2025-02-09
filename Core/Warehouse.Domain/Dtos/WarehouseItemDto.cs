namespace Warehouse.Domain.Dtos
{
	public class WarehouseItemDto
	{
		public int Id { get; set; } // Уникальный идентификатор позиции на складе
		public int BookId { get; set; } // ID книги из микросервиса "Книжный интернет-магазин"
		public int Quantity { get; set; } // Количество книг на складе
	}
}
