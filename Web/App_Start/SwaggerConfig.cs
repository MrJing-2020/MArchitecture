using System.Web.Http;
using WebActivatorEx;
using Web;
using Swashbuckle.Application;
using Web.Providers;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Web
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Web");
                        c.IncludeXmlComments(string.Format("{0}/bin/Web.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                        c.IncludeXmlComments(string.Format("{0}/bin/Models.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                        c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.InjectStylesheet(thisAssembly, "Web.Content.bootstrap.min.css");
                        c.InjectStylesheet(thisAssembly, "Web.Content.cumSwagger.css");
                        c.InjectJavaScript(thisAssembly, "Web.Scripts.swagger_lang.js");
                        c.InjectJavaScript(thisAssembly, "Web.Scripts.bootstrap.min.js");
                    });
        }
    }
}
