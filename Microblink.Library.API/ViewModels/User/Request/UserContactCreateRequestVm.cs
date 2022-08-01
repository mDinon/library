using Microblink.Library.API.ValidationAttributes;
using Microblink.Library.Service.Enums;
using System.ComponentModel.DataAnnotations;

namespace Microblink.Library.API.ViewModels.User.Request
{
	/// <summary>
	/// User contact create request view model class
	/// </summary>
	public class UserContactCreateRequestVm
	{
		/// <summary>
		/// Contact type property
		/// </summary>
		[RequiredEnum(ErrorMessage = "The ContactType field is required or has incorrect value.")]
		public ContactTypeEnum ContactTypeId { get; set; }
		/// <summary>
		/// Value property
		/// </summary>
		[Required]
		[MaxLength(255)]
		public string Value { get; set; } = string.Empty;
	}
}
