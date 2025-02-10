using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain.Dtos;
using Warehouse.Domain.Interfaces.Services;
using Warehouse.Domain.Services;

namespace Warehouse.WebApi.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("2.0")]
	public class WriteOffOperationController : ControllerBase
	{
		private readonly IWriteOffOperationService _service;

		public WriteOffOperationController(IWriteOffOperationService service)
		{
			_service = service;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<WriteOffOperationDto>> GetWriteOffOperation(int id, CancellationToken cancellationToken)
		{
			var item = await _service.GetByIdAsync(id, cancellationToken);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		[HttpPost]
		public async Task<ActionResult<WriteOffOperationDto>> CreateWriteOffOperation(WriteOffOperationDto createDto, CancellationToken cancellationToken)
		{
			try
			{
				var item = await _service.CreateAsync(createDto, cancellationToken);
				return CreatedAtAction(nameof(GetWriteOffOperation), new { id = item.Id }, item);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdateWriteOffOperation(WriteOffOperationDto updateDto, CancellationToken cancellationToken)
		{
			try
			{
				await _service.UpdateAsync(updateDto, cancellationToken);
				return NoContent();
			}
			catch (KeyNotFoundException)
			{
				return NotFound();
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWriteOffOperation(int id, CancellationToken cancellationToken)
		{
			await _service.DeleteAsync(id, cancellationToken);
			return NoContent();
		}
	}
}
