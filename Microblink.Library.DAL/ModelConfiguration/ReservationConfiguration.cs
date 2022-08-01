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
					DateCreated = DateTime.Now,
					BookId = 2,
					UserId = 1,
					IsReservationActive = true,
					ReservationDateStart = DateTime.Now.Date,
					ReservationDueDate = DateTime.Now.Date.AddDays(10),
					IsDeleted = false
				},
				new Reservation()
				{
					Id = 2,
					DateCreated = DateTime.Now,
					BookId = 3,
					UserId = 1,
					IsReservationActive = false,
					ReservationDateStart = DateTime.Now.Date.AddDays(-15),
					ReservationDueDate = DateTime.Now.Date.AddDays(-5),
					ReservationDateEnd = DateTime.Now.Date.AddDays(-10),
					IsDeleted = false
				},
				new Reservation()
				{
					Id = 3,
					DateCreated = DateTime.Now,
					BookId = 1,
					UserId = 1,
					IsReservationActive = true,
					ReservationDateStart = DateTime.Now.Date.AddDays(-15),
					ReservationDueDate = DateTime.Now.Date.AddDays(-5),
					IsDeleted = false
				});
		}
	}
}
