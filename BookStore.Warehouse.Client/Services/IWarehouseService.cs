using BookStore.Warehouse.Client.Dtos;
using Skreet2k.Common.Models;

namespace BookStore.Warehouse.Client.Services
{
    public interface IWarehouseService
    {
        Task<Result<string>> ProcessOrder(OrderDto orderDto);
    }
}