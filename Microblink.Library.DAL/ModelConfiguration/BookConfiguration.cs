using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblink.Library.DAL.ModelConfiguration
{
	internal class BookConfiguration : BaseConfiguration<Book>
	{
		public override void Configure(EntityTypeBuilder<Book> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Id).HasColumnName("ID");
			builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Author).IsRequired().HasMaxLength(255);
			builder.Property(x => x.TotalCopies).IsRequired();
		}
	}
}
