using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblink.Library.DAL.ModelConfiguration
{
	internal class UserContactConfiguration : BaseConfiguration<UserContact>
	{
		public override void Configure(EntityTypeBuilder<UserContact> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Id).HasColumnName("ID");
			builder.Property(x => x.UserId).IsRequired();
			builder.Property(x => x.ContactTypeId).IsRequired();
			builder.Property(x => x.Value).IsRequired().HasMaxLength(255);
		}
	}
}
