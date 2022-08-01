using System.ComponentModel.DataAnnotations;

namespace Microblink.Library.API.ValidationAttributes
{
	/// <summary>
	/// Check if enum is not null and is in defined range
	/// </summary>
	public class RequiredEnumAttribute : RequiredAttribute
	{
		/// <summary>
		/// Check if enum is not null and has valid value
		/// </summary>
		/// <param name="value"></param>
		/// <returns>True if enum is not null and is in defined values range</returns>
		public override bool IsValid(object? value)
		{
			if (value is null)
			{
				return false;
			}

			Type? type = value.GetType();

			return type.IsEnum && Enum.IsDefined(type, value);
		}
	}
}
