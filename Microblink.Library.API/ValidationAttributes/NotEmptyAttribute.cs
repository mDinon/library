using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Microblink.Library.API.ValidationAttributes
{
	/// <summary>
	/// Not empty validation attribute used for validating lists
	/// </summary>
	public class NotEmptyAttribute : ValidationAttribute
	{
		/// <summary>
		/// Check if list is not null or empty
		/// </summary>
		/// <param name="value"></param>
		/// <returns>True if list has value</returns>
		public override bool IsValid(object? value)
		{
			return value is IList list && list.Count > 0;
		}
	}
}
