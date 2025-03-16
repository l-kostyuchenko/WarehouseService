namespace BookStore.Warehouse.Client.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }        
    }
}
