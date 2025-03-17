namespace BookStore.Warehouse.Client.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }              
    }
}
