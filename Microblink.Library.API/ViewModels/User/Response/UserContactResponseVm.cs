using Microblink.Library.Service.Enums;

namespace Microblink.Library.API.ViewModels.User.Response
{
	/// <summary>
	/// User contact response view model class
	/// </summary>
	public class UserContactResponseVm
	{
		/// <summary>
		/// Id property
		/// </summary>
		public int? Id { get; set; }
		/// <summary>
		/// User id property
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// Contact type property
		/// </summary>
		public ContactTypeEnum ContactType { get; set; }
		/// <summary>
		/// Contact type name property
		/// </summary>
		public string ContactTypeName { get; set; } = string.Empty;
		/// <summary>
		/// Contact value property
		/// </summary>
		public string Value { get; set; } = string.Empty;
	}
}
