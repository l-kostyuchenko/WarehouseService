using Asp.Versioning;
using BookStore.Warehouse.Client.Dtos;
using BookStore.Warehouse.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain.Interfaces.Services;
using Warehouse.Domain.Services;

namespace Warehouse.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[ApiVersion("1.0")]
	public class WarehouseController : ControllerBase
	{
		private readonly IWriteOffOperationService _writeOffOperationService;
		private readonly IWarehouseItemService _warehouseItemService;

		public WarehouseController(IWriteOffOperationService writeOffOperationService, 
			IWarehouseItemService warehouseItemService)
		{
			_writeOffOperationService = writeOffOperationService;
			_warehouseItemService = warehouseItemService;
		}

		[HttpPost("ProcessOrder")]
		public async Task<IActionResult> ProcessOrder([FromBody] OrderDto order)
		{
			try
			{
				await _writeOffOperationService.ProcessOrder(order); 
				return Ok("Обработано успешно");
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка обработки: {ex.Message}");
			}
		}

		[HttpGet("GetBookCount")]
		public async Task<IActionResult> GetBookCount(int bookId)
		{
			try
			{
				var res = await _warehouseItemService.GetWarehouseItemByBookIdAsync(bookId, CancellationToken.None);
				return Ok(res?.Quantity);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка обработки: {ex.Message}");
			}
		}
	}
}
