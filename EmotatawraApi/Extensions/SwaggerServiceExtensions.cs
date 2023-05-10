using Microsoft.OpenApi.Models;

namespace EmotatawraApi.Extensions
{
	public static class SwaggerServiceExtensions
	{
		public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				//c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airline.APIs", Version = "v1" });
				var security = new OpenApiSecurityScheme
				{
					Description = "JWT Auth Bearer Scheme",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "Bearer",
					Reference = new OpenApiReference
					{
						Id = "Bearer",
						Type = ReferenceType.SecurityScheme
					}
				};
				c.AddSecurityDefinition("Bearer", security);
				var securityRequirement = new OpenApiSecurityRequirement
				{
					{ security,new []{"Bearer"} }
				};
				c.AddSecurityRequirement(securityRequirement);
			});
			return services;
		}
	}
}
