using Microblink.Library.API.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Microblink.Library.API.ViewModels.User.Request
{
	/// <summary>
	/// User create request view model class
	/// </summary>
	public class UserUpdateRequestVm
	{
		/// <summary>
		/// Id property
		/// </summary>
		[Required]
		public int Id { get; set; }
		/// <summary>
		/// First name property
		/// </summary>
		[Required]
		[MaxLength(255)]
		public string FirstName { get; set; } = string.Empty;
		/// <summary>
		/// Last name property
		/// </summary>
		[Required]
		[MaxLength(255)]
		public string LastName { get; set; } = string.Empty;
		/// <summary>
		/// Date of birth property
		/// </summary>
		[Required]
		[DataType(DataType.Date)]
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// User contacts collection
		/// </summary>
		[NotEmpty]
		public IEnumerable<UserContactUpdateRequestVm> UserContacts { get; set; } = null!;
	}
}
