using System.Diagnostics;

namespace week_3_assignment.Middlewares
{
	public class CustomExceptionMiddleware
	{

        private readonly RequestDelegate _requestDelegate;

		public CustomExceptionMiddleware(RequestDelegate requestDelegate)
		{
			_requestDelegate = requestDelegate;
		}

		public async Task Invoke(HttpContext context)
		{
			var watch = Stopwatch.StartNew();
			string message = "[Request] HTTP " + context.Request.Method + " " + context.Request.Path;
			Console.WriteLine(message);
			await _requestDelegate(context);
			watch.Stop();
			message = "[Response] HTTP " + context.Request.Method + " " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms " ;
			Console.WriteLine(message);
		}
	}

	public static class CustomExceptionMiddlewareException
	{
		public static IApplicationBuilder UseCostomExceptionMiddle(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CustomExceptionMiddleware>();
		}
	}
}
