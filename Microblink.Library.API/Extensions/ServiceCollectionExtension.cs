using Microblink.Library.DAL.Context;
using Microblink.Library.Service;
using Microblink.Library.Service.Interfaces;
using Microblink.Library.Service.Mapping;
using Microblink.Library.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Microblink.Library.API.Extensions
{
	/// <summary>
	/// ServiceCollection extension providing extra methods
	/// </summary>
	public static partial class ServiceCollectionExtension
	{
		#region AddCustomOptions

		/// <summary>
		/// Add custom options. Eg. AppSettings
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
		{
			return services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
		}

		#endregion

		#region AddSwagger

		/// <summary>
		/// Configure Swagger docs
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.IncludeXmlComments("Microblink.Library.API.xml");
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microblink.Library.API", Version = "v1" });
			});

			return services;
		}

		#endregion

		#region AddDbContext

		/// <summary>
		/// Add database context
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddDbContext<LibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("LibraryConnection"),
					opts =>
					{
						opts.CommandTimeout((int)TimeSpan.FromMinutes(1).TotalSeconds);
						opts.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
						opts.EnableRetryOnFailure(2);
					}));

			return services;
		}

		#endregion

		#region AddServices

		/// <summary>
		/// Register services
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services
					.AddTransient<IUserService, UserService>();

			return services;
		}

		#endregion

		#region AddMappers

		/// <summary>
		/// Add mapping profiles
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddMappers(this IServiceCollection services)
		{
			AutoMapper.MapperConfiguration mappingConfig = new(mc =>
			{
				mc.AddProfile(new Mapping.MappingProfile());
				mc.AddProfile(new MappingProfile());
			});

			services.AddSingleton(mappingConfig.CreateMapper());
			return services;
		}

		#endregion

		#region AddCustomCors

		/// <summary>
		/// Configure CORS
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
		{
			IEnumerable<IConfigurationSection> apiCorsConfig = configuration.GetSection("Microblink.Library.API.Cors").GetChildren();

			if (!apiCorsConfig.Any(c => c.GetValue<string>("CorsPolicyName") == "AllowAll"))
			{
				services.AddCors(o =>
				{
					o.AddPolicy(
						"AllowAll",
						builder =>
						{
							builder.WithOrigins("http://localhost:3000")
								.AllowAnyMethod()
								.AllowAnyHeader()
								.AllowCredentials();
						});
				});
			}

			foreach (IConfigurationSection corsConfig in apiCorsConfig)
			{
				string corsName = corsConfig["CorsPolicyName"];
				bool corsEnabled = corsConfig.GetValue<bool>("Enabled");
				string[] urlOrigins = corsConfig.GetSection("Origins").GetChildren().Select(c => c.Value).ToArray();

				if (corsEnabled)
				{
					services.AddCors(o =>
					{
						o.AddPolicy(
							corsName,
							builder =>
							{
								builder.WithOrigins(urlOrigins)
									.AllowAnyMethod()
									.AllowAnyHeader()
									.AllowCredentials();
							});
					});
				}
			}

			return services;
		}

		#endregion
	}
}
