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
			builder.HasData(
				new Reservation()
				{
					Id = 1,
					DateCreated = new DateTime(2022, 8, 2),
					BookId = 2,
					UserId = 1,
					IsReservationActive = true,
					ReservationDateStart = new DateTime(2022, 8, 2).Date,
					ReservationDueDate = new DateTime(2022, 8, 2).Date.AddDays(20),
					IsDeleted = false
				},
				new Reservation()
				{
					Id = 2,
					DateCreated = new DateTime(2022, 8, 2),
					BookId = 3,
					UserId = 1,
					IsReservationActive = false,
					ReservationDateStart = new DateTime(2022, 8, 2).Date.AddDays(-15),
					ReservationDueDate = new DateTime(2022, 8, 2).Date.AddDays(-5),
					ReservationDateEnd = new DateTime(2022, 8, 2).Date.AddDays(-10),
					IsDeleted = false
				},
				new Reservation()
				{
					Id = 3,
					DateCreated = new DateTime(2022, 8, 2),
					BookId = 1,
					UserId = 1,
					IsReservationActive = true,
					ReservationDateStart = new DateTime(2022, 8, 2).Date.AddDays(-15),
					ReservationDueDate = new DateTime(2022, 8, 2).Date.AddDays(-5),
					IsDeleted = false
				});
		}
	}
}
