using System.ComponentModel.DataAnnotations.Schema;

namespace Microblink.Library.Model.Entities
{
	public class Reservation : EntityBase
	{
		[ForeignKey("Book")]
		public int BookId { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
		public DateTime ReservationDateStart { get; set; }
		public DateTime ReservationDueDate { get; set; }
		public DateTime? ReservationDateEnd { get; set; }
		public bool IsReservationActive { get; set; }

		public virtual Book Book { get; set; } = null!;
		public virtual User User { get; set; } = null!;
	}
}
