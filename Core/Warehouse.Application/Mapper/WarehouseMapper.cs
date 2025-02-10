using Riok.Mapperly.Abstractions;
using Warehouse.Domain.Dtos;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Mapper
{
	[Mapper]
	public static partial class WarehouseMapper
	{
		public static partial WarehouseItemDto ToDto(WarehouseItem entity);
		public static partial WarehouseItem ToEntity(WarehouseItemDto dto);
		public static partial WarehouseItem ToEntity(CreateWarehouseItemDto dto);

		public static partial WriteOffOperationDto ToDto(WriteOffOperation entity);
		public static partial WriteOffOperation ToEntity(WriteOffOperationDto dto);
	}
}
