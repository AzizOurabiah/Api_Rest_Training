using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;

namespace Api.Bibiliotheque.Core.Net.Configuration
{
    /// <summary>
    /// tous nos extensions de service de configuration pour plus de clarté
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddSwaggerGenService(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mon Api Bibliothèque",
                    Description = "Api de gestion de bibliothèque pour mes clients.",
                    TermsOfService = new Uri("https://monapibiblio/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Auteur1",
                        Email ="helloauteur@udemy.com",
                        Url = new Uri("mailto:helloauteur@udemy.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name ="Example licence",
                        Url = new Uri("https://monapibiblio/licences")
                    }
                });


                //lecture du fichier xml pour swagger
                //var xmlhelp = Assembly.GetExecutingAssembly().GetName()+xml
                var xmlhelp = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlhelp));

            });

            

            return service;
        }

        public static IServiceCollection AddAuthentificationService(this IServiceCollection service)
        {
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = "";
                options.Audience = "";
            });
            return service;
        }
    }
}
