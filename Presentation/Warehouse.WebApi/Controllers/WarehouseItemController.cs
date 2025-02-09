using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain.Dtos;
using Warehouse.Domain.Services;

namespace Warehouse.WebApi.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class WarehouseItemController : ControllerBase
	{
		private readonly IWarehouseItemService _warehouseService;

		public WarehouseItemController(IWarehouseItemService warehouseService)
		{
			_warehouseService = warehouseService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<WarehouseItemDto>> GetWarehouseItem(int id, CancellationToken cancellationToken)
		{
			var item = await _warehouseService.GetWarehouseItemByIdAsync(id, cancellationToken);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		[HttpPost]
		public async Task<ActionResult<WarehouseItemDto>> CreateWarehouseItem(CreateWarehouseItemDto createDto, CancellationToken cancellationToken)
		{
			try
			{
				var item = await _warehouseService.CreateWarehouseItemAsync(createDto, cancellationToken);
				return CreatedAtAction(nameof(GetWarehouseItem), new { id = item.Id }, item);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdateWarehouseItem(WarehouseItemDto updateDto, CancellationToken cancellationToken)
		{
			try
			{
				await _warehouseService.UpdateWarehouseItemAsync(updateDto, cancellationToken);
				return NoContent();
			}
			catch (KeyNotFoundException)
			{
				return NotFound();
			}
		}
	}
}
