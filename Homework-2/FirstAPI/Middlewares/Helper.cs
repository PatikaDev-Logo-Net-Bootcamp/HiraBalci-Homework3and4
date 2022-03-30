
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApplication1.Helper
{
    public class Helper: IOperationFilter
    {
        
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //IOperationFilter kütüphanesidir.Swagger headerına app-version default key eklendi.

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "app-version",
                In = ParameterLocation.Header,
                Description = "Application version",
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("2.0.0")
                }
            });

        }
    }
}