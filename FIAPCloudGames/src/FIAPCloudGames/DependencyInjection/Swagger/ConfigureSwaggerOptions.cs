using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FIAPCloudGames.DependencyInjection.Swagger
{
    public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var apiDescription in _provider.ApiVersionDescriptions)
            {
                var apiVersionModel = apiDescription.GroupName;
                if (apiVersionModel != null)
                {
                    options.SwaggerDoc(apiVersionModel, new OpenApiInfo { Title = apiDescription.GroupName, Version = apiVersionModel });
                }
            }
        }
    }
}
