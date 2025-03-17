using BookStore.Warehouse.Client.Dtos;
using Refit;

namespace BookStore.Warehouse.Client.Interfaces
{
	public interface IWarehouseApi
    {
        [Post("/api/Warehouse/ProcessOrder")] 
        Task<ApiResponse<string>> ProcessOrder([Body] OrderDto order);

		[Get("/api/Warehouse/GetBookCount")]
		Task<ApiResponse<int>> GetBookCount(int bookId);
	}
}
