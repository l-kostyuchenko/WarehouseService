using BookStore.Warehouse.Client.Dtos;
using BookStore.Warehouse.Client.Interfaces;
using Refit;
using Skreet2k.Common.Models;

namespace BookStore.Warehouse.Client.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseApi _api;

        public WarehouseService(IWarehouseApi api)
        {
            _api = api;
        }

		public async Task<Result<int>> GetBookCount(int bookId)
		{
			var result = await _api.GetBookCount(bookId);

			return HandleResponse(result);
		}

		public async Task<Result<string>> ProcessOrder(OrderDto orderDto)
        {
            var result = await _api.ProcessOrder(orderDto);

            return HandleResponse(result);
        }

        private Result<T> HandleResponse<T>(ApiResponse<T> result)
        {
            if (result.IsSuccessStatusCode && result.Content is not null)
            {
                return new Result<T>(result.Content);
            }

            if (result.Error is not null)
            {
                return new Result<T>()
                {
                    ErrorMessage = result.Error.Content ?? result.Error.Message
                };
            }

            return new Result<T>()
            {
                ErrorMessage = result.ReasonPhrase
            };
        }
    }
}
