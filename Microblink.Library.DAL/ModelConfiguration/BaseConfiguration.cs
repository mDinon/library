using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblink.Library.DAL.ModelConfiguration
{
	public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasQueryFilter(x => !x.IsDeleted);
			builder.Property(x => x.DateCreated).HasDefaultValueSql("(getdate())").ValueGeneratedOnAdd();
			builder.Property(x => x.DateModified);
			builder.Property(x => x.IsDeleted);
		}
	}
}
