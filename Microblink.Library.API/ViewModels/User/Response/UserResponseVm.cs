namespace Microblink.Library.API.ViewModels.User.Response
{
	/// <summary>
	/// User reponse view model class
	/// </summary>
	public class UserResponseVm
	{
		/// <summary>
		/// Id property
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// First name property
		/// </summary>
		public string FirstName { get; set; } = string.Empty;
		/// <summary>
		/// Last name property
		/// </summary>
		public string LastName { get; set; } = string.Empty;
		/// <summary>
		/// Date of birth property
		/// </summary>
		public DateTime DateOfBirth { get; set; } = DateTime.Now;

		/// <summary>
		/// User contacts collection
		/// </summary>
		public IEnumerable<UserContactResponseVm> UserContacts { get; set; } = null!;
	}
}
