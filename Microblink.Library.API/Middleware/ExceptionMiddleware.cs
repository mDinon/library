using Microblink.Library.Service.Exceptions;
using System.Net;
using System.Text.Json;

namespace Microblink.Library.API.Middleware
{
	/// <summary>
	/// Exception middleware providing error handling in one place
	/// </summary>
	public class ExceptionMiddleware
	{
		#region Fields

		private readonly RequestDelegate next;
		private readonly ILogger<ExceptionMiddleware> logger;
		private readonly IWebHostEnvironment env;

		#endregion

		#region Constructor

		/// <summary>
		/// Exception middleware constructor
		/// </summary>
		/// <param name="next"></param>
		/// <param name="logger"></param>
		/// <param name="env"></param>
		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
		{
			this.logger = logger;
			this.next = next;
			this.env = env;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Invoking request and handle error if it fails
		/// </summary>
		/// <param name="httpContext"></param>
		/// <returns></returns>
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			logger.LogError(ex, "An error has occurred: {Message}", ex.Message);

			HttpStatusCode status;
			string message;
			string result;

			if (ex is UnauthorizedAccessException)
			{
				message = ex.Message;
				status = HttpStatusCode.Unauthorized;
			}
			else if (ex is ArgumentException || ex is InvalidOperationException)
			{
				message = ex.Message;
				status = HttpStatusCode.BadRequest;
			}
			else if (ex is ItemNotFoundException)
			{
				message = ex.Message;
				status = HttpStatusCode.NotFound;
			}
			else
			{
				status = HttpStatusCode.InternalServerError;
				message = ex.Message;
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)status;

			if (env.IsDevelopment())
				result = JsonSerializer.Serialize(new { error = message, statusCode = status, ex.StackTrace });
			else
				result = JsonSerializer.Serialize(new { error = message, statusCode = status });

			return context.Response.WriteAsync(result);
		}

		#endregion
	}
}
