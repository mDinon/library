using Microblink.Library.Service.Enums;

namespace Microblink.Library.Service.Dtos
{
	public class UserContactDto
	{
		public int? Id { get; set; }
		public int UserId { get; set; }
		public ContactTypeEnum ContactTypeId { get; set; }
		public string ContactTypeName { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;
	}
}
