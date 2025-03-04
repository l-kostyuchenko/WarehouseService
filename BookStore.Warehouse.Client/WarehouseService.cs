using BookStore.Warehouse.Client.Dtos;
using BookStore.Warehouse.Client.Interfaces;

namespace BookStore.Warehouse.Client
{
	public interface IWarehouseService
	{
		Task<string> ProcessOrder(OrderDto orderDto);
	}

	public class WarehouseService : IWarehouseService
	{
		private readonly IWarehouseApi _api;

		public WarehouseService(IWarehouseApi api)
		{
			_api = api;
		}

		public async Task<string> ProcessOrder(OrderDto orderDto)
		{
			var res = await _api.ProcessOrder(orderDto);

			//TODO

			if (res.StatusCode == System.Net.HttpStatusCode.BadRequest)
			{
				return "Неверный запрос";
			}

			return res.Content;
		}
	}
}
