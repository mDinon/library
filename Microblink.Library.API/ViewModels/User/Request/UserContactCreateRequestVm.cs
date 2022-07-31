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
		[Required]
		public ContactTypeEnum ContactType { get; set; }
		/// <summary>
		/// Value property
		/// </summary>
		[Required]
		[MaxLength(255)]
		public string Value { get; set; } = string.Empty;
	}
}
