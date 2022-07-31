namespace Microblink.Library.Model.Entities
{
	public class Book : EntityBase
	{
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public int TotalCopies { get; set; }

		public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
	}
}
