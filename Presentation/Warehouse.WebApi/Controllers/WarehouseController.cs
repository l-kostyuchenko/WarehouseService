using Asp.Versioning;
using BookStore.Warehouse.Client.Dtos;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain.Interfaces.Services;

namespace Warehouse.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[ApiVersion("1.0")]
	public class WarehouseController : ControllerBase
	{
		private readonly IWriteOffOperationService _service;

		public WarehouseController(IWriteOffOperationService warehouseService)
		{
			_service = warehouseService;
		}

		[HttpPost("ProcessOrder")]
		public async Task<IActionResult> ProcessOrder([FromBody] OrderDto order)
		{
			try
			{
				await _service.ProcessOrder(order); 
				return Ok("Обработано успешно");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Ошибка обработки: {ex.Message}");
			}
		}
	}
}
