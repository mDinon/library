using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microblink.Library.DAL.ModelConfiguration
{
	internal class ReservationConfiguration : BaseConfiguration<Reservation>
	{
		public override void Configure(EntityTypeBuilder<Reservation> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Id).HasColumnName("ID");
			builder.Property(x => x.BookId).IsRequired();
			builder.Property(x => x.UserId).IsRequired();
			builder.Property(x => x.ReservationDateStart).IsRequired();
			builder.Property(x => x.ReservationDueDate).IsRequired();
			builder.Property(x => x.IsReservationActive).IsRequired();
		}
	}
}
