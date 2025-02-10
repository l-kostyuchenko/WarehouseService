using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Dtos
{
	public class WriteOffOperationDto
	{
		public int Id { get; set; }

		public DateTimeOffset OperationDate { get; set; }

		public List<OperationItem> OperationItems { get; set; } = new List<OperationItem>();
	}
}
