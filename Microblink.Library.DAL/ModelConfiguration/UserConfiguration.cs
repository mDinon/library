using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblink.Library.DAL.ModelConfiguration
{
	internal class UserConfiguration : BaseConfiguration<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Id).HasColumnName("ID");
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
			builder.Property(x => x.DateOfBirth).IsRequired();
		}
	}
}
