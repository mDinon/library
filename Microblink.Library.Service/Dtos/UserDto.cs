namespace Microblink.Library.Service.Dtos
{
	public class UserDto
	{
		public int? Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; } = DateTime.Now;

		public IEnumerable<UserContactDto> UserContacts { get; set; } = null!;
	}
}
