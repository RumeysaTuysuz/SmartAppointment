using System.Net;
using System.Text.Json;

namespace SmartAppointment.API.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var response = new
			{
				statusCode = context.Response.StatusCode,
				message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin."
			};

			return context.Response.WriteAsync(JsonSerializer.Serialize(response));
		}
	}
}
