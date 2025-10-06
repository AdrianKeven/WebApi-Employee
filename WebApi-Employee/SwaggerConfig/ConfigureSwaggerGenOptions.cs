using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi_Employee.SwaggerConfig
{
    // Configura as opções do SwaggerGen para suportar múltiplas versões de API
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public void Configure(SwaggerGenOptions options)
        {
            // Adiciona um documento Swagger para cada versão de API descoberta
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));

            }
        }

        // Cria a descrição OpenAPI para uma versão de API específica
        private static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Employee API - Adrian Keven Dev",
                Version = description.ApiVersion.ToString(),
                Description = "A simple example ASP.NET Core Web API for managing employees",
            };

            if (description.IsDeprecated)
            {
                info.Description += "(deprecated)";
            }

            return info;
        }
    }
}