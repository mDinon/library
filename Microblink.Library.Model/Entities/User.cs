namespace Microblink.Library.Model.Entities
{
	public class User : EntityBase
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; } = DateTime.Now;

		public virtual ICollection<UserContact> UserContacts { get; set; } = new List<UserContact>();
		public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
	}
}
