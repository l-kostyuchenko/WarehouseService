﻿namespace Warehouse.Domain.Dtos
{
	public class WriteOffOperationDto
	{
		public int Id { get; set; }

		public DateTimeOffset OperationDate { get; set; }

		public List<OperationItemDto> OperationItems { get; set; } = new List<OperationItemDto>();
	}
}
