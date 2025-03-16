using BookStore.Warehouse.Client.Dtos;
using Riok.Mapperly.Abstractions;
using Warehouse.Domain.Dtos;

namespace Warehouse.Application.Mapper
{
	[Mapper]
	public static partial class OrderMapper
	{
		[MapProperty(nameof(OrderDto.OrderItems), nameof(WriteOffOperationDto.OperationItems), Use = nameof(MapOrderItemsToOperationItems))]
		[MapProperty(nameof(OrderDto.OrderDate), nameof(WriteOffOperationDto.OperationDate))]
		[MapProperty(nameof(OrderDto.Id), nameof(WriteOffOperationDto.Id))]
		public static partial WriteOffOperationDto ToWriteOffOperationDto(OrderDto orderDto);

		private static OperationItemDto MapOrderItem(OrderItemDto orderItem)
		{
			return new OperationItemDto
			{
				//BaseOperationId = 0,
				WarehouseItemId = orderItem.BookId,
				Count = orderItem.Quantity,
				Price = 0, // Установите цену
			};
		}

		private static List<OperationItemDto> MapOrderItemsToOperationItems(List<OrderItemDto> orderItems)
		{
			WriteOffOperationDto writeOffOperationDto = new WriteOffOperationDto();

			return orderItems.Select(orderItem => MapOrderItem(orderItem)).ToList();
		}

	}
}
