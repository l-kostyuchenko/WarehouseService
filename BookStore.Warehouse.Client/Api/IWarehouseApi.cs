using BookStore.Warehouse.Client.Dtos;
using Refit;

namespace BookStore.Warehouse.Client.Interfaces
{
	public interface IWarehouseApi
    {
        [Post("/api/Warehouse/ProcessOrder")] 
        Task<ApiResponse<string>> ProcessOrder([Body] OrderDto order); 
    }
}
