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
			builder.HasData(
				new UserContact()
				{
					Id = 1,
					DateCreated = new DateTime(2022, 8, 2),
					ContactTypeId = 1,
					UserId = 1,
					Value = "test.test@test.test",
					IsDeleted = false
				},
				new UserContact()
				{
					Id = 2,
					DateCreated = new DateTime(2022, 8, 2),
					ContactTypeId = 2,
					UserId = 1,
					Value = "+385987456123",
					IsDeleted = false
				},
				new UserContact()
				{
					Id = 3,
					DateCreated = new DateTime(2022, 8, 2),
					ContactTypeId = 3,
					UserId = 1,
					Value = "011234567",
					IsDeleted = false
				});
		}
	}
}
