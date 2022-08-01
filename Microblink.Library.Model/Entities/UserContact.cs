using System.ComponentModel.DataAnnotations.Schema;

namespace Microblink.Library.Model.Entities
{
	public class UserContact : EntityBase
	{
		[ForeignKey("User")]
		public int UserId { get; set; }
		[ForeignKey("ContactTypeId")]
		public int ContactTypeId { get; set; }
		public string Value { get; set; } = string.Empty;

		public virtual User User { get; set; } = null!;
		public virtual ContactType ContactType { get; set; } = null!;
	}
}
