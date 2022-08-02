using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblink.Library.DAL.ModelConfiguration
{
	internal class ContactTypeConfiguration : BaseConfiguration<ContactType>
	{
		public override void Configure(EntityTypeBuilder<ContactType> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
			builder.HasData(
				new ContactType()
				{
					Id = 1,
					DateCreated = new DateTime(2022, 8, 2),
					Name = "Email",
					IsDeleted = false
				},
				new ContactType()
				{
					Id = 2,
					DateCreated = new DateTime(2022, 8, 2),
					Name = "Mobile",
					IsDeleted = false
				},
				new ContactType()
				{
					Id = 3,
					DateCreated = new DateTime(2022, 8, 2),
					Name = "Telephone",
					IsDeleted = false
				});
		}
	}
}
