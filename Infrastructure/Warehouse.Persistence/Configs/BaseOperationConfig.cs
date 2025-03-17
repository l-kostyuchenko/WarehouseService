using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.Persistence.Configs
{
	public class BaseOperationConfig : IEntityTypeConfiguration<BaseOperation>
	{
		public void Configure(EntityTypeBuilder<BaseOperation> builder)
		{
			builder.ToTable("operations");
			builder.HasKey(x => x.Id);
			builder.HasMany(x => x.OperationItems).WithOne(x => x.Operation);

			builder.HasDiscriminator<string>("operation_type");
		}
	}
}
