using BookStore.Warehouse.Client.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Warehouse.Client.Dtos;

namespace BookStore.Warehouse.Client.Interfaces
{
    public interface IWarehouseApi
    {
        [Post("/api/warehouse/processorder")] 
        Task<ApiResponse<string>> ProcessOrder([Body] OrderDto order); 
    }
}
