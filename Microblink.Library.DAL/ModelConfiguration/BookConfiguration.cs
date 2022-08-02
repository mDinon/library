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
			builder.HasData(
				new Book()
				{
					Id = 1,
					DateCreated = new DateTime(2022, 8, 2),
					Title = "Harry Potter and the Philosopher's Stone",
					Author = "J. K. Rowling",
					TotalCopies = 10,
					IsDeleted = false
				},
				new Book()
				{
					Id = 2,
					DateCreated = new DateTime(2022, 8, 2),
					Title = "Dune",
					Author = "Frank Herbert",
					TotalCopies = 3,
					IsDeleted = false
				},
				new Book()
				{
					Id = 3,
					DateCreated = new DateTime(2022, 8, 2),
					Title = "The Lord of the Rings",
					Author = "J. R. R. Tolkien",
					TotalCopies = 13,
					IsDeleted = false
				});
		}
	}
}
