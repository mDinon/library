using Microblink.Library.API.Extensions;
using Serilog;
using System.Diagnostics;

IConfiguration configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
			.AddEnvironmentVariables()
			.Build();

Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();

Serilog.Debugging.SelfLog.Enable(msg =>
{
	Debug.Print(msg);
	Debugger.Break();
});

try
{
	Log.Information("Microblink.Library.API Starting...");
	var builder = WebApplication.CreateBuilder(args);

	builder.Host.UseSerilog();

	// Add services to the container.
	builder.Services.AddControllers();
	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	builder.Services.AddEndpointsApiExplorer();
	builder.Services
		.AddSwagger()
		.AddCustomOptions(builder.Configuration)
		.AddCustomCors(builder.Configuration)
		.AddDbContext(builder.Configuration)
		.AddServices()
		.AddMappers();

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();

	app.ConfigureCustomExceptionMiddleware();

	app.UseCors("AllowAll");

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "Microblink.Library.API failed to start.");
}
finally
{
	Log.CloseAndFlush();
}
