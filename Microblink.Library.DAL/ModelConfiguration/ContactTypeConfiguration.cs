using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblink.Library.DAL.ModelConfiguration
{
	internal class ContactTypeConfiguration : BaseConfiguration<ContactType>
	{
		public override void Configure(EntityTypeBuilder<ContactType> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Name).IsRequired();
			builder.HasData(
				new ContactType()
				{
					Id = 1,
					DateCreated = DateTime.Now,
					Name = "Email",
					IsDeleted = false
				},
				new ContactType()
				{
					Id = 2,
					DateCreated = DateTime.Now,
					Name = "Mobile",
					IsDeleted = false
				},
				new ContactType()
				{
					Id = 3,
					DateCreated = DateTime.Now,
					Name = "Telephone",
					IsDeleted = false
				});
		}
	}
}
