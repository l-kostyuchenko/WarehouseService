using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Entities
{
	public class OperationItem : BaseEntity
	{
		public int BaseOperationId { get; set; }
		public required BaseOperation BaseOperation { get; set; }

		public int WarehouseItemId { get; set; }
		public required WarehouseItem WarehouseItem { get; set; }

		public int Count { get; set; }
		public decimal Price { get; set; }
	}
}
