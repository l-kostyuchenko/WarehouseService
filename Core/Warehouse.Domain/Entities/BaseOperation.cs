using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Entities
{
	public class BaseOperation : BaseEntity
	{
		public DateTimeOffset OperationDate { get; set; }

		public List<OperationItem> OperationItems { get; set; } = new List<OperationItem>();
	}
}
