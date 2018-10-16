using System.Web.Http;
using WebActivatorEx;
using WebExperience.Test;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebExperience.Test
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebExperience.Test");     
                    })
                .EnableSwaggerUi(c =>
                    {});
        }
    }
}
