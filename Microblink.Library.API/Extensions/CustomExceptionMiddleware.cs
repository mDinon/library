using Microblink.Library.API.Middleware;

namespace Microblink.Library.API.Extensions
{
	/// <summary>
	/// Custom exception middleware app builder extension used for registering exception middleware
	/// </summary>
	public static class CustomExceptionMiddleware
	{
		/// <summary>
		/// Specify using of exception middleware
		/// </summary>
		/// <param name="app"></param>
		public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
