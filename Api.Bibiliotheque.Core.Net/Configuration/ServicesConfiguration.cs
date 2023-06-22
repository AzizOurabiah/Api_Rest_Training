using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;
using System.Security.AccessControl;

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
                //Connecté notre api qu'on a crée dans le sit auth0 avec le service d'auhtentification
                //Veut dire l'API qu'on a crée c'est elle qui a controller les autorisations
                //Sit de l'API https://manage.auth0.com/dashboard/us/dev-ngm40o1ql0uwhp0y/apis

                options.Authority = "https://dev-ngm40o1ql0uwhp0y.us.auth0.com";//On va déligué l'authentification à l'API qu'on a crée 
                options.Audience = "https://demonstrationnet6/";//On va déligué l'audience à l'API qu'on a crée

            });
            return service;
        }
        //Méthode qui permet d'appliquer filtre sur tous les controller on va l'appeler dans le fichier programme
        public static IServiceCollection AddControllersService(this IServiceCollection service)
        {
            service.AddControllers(options =>
            {
                //On a spécifie que l'autorisation est requis  
                var policies = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policies));
            });
            return service;
        }
    }
}
