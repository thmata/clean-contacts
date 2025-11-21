using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace Api.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            var info = new OpenApiInfo
            {
                Title = "CleanContacts API",
                Version = "v1",
                Description = "API para gerenciamento de contatos",
                Contact = new OpenApiContact
                {
                    Name = "CleanContacts",
                    Email = "contato@cleancontacts.com"
                }
            };

            options.SwaggerDoc("v1", info);

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme.ToLower(),
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT no formato: Bearer {seu token}"
            };

            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

            options.AddSecurityRequirement(doc =>
            {
                var securitySchemeRef = new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, doc);
                var requirement = new OpenApiSecurityRequirement
                {
                    { securitySchemeRef, new List<string>() }
                };
                return requirement;
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanContacts API v1");
            options.RoutePrefix = "swagger";
            options.DocumentTitle = "CleanContacts API - Documentação";
        });

        return app;
    }
}
