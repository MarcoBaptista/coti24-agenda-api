using Microsoft.IdentityModel.Tokens;

namespace AgendaApp.API.Extensions
{
    //Classe de extensão para configurar a política de cors(segurança para qual projeto irá acessar) da API(
    public static class CorsConfigExtension
    {
        //atributos
        private static string _policyName = "DefaultPolicy";
        public static string[] _origins = { "http://localhost:4200" };
        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(_policyName, policy =>
                {
                    policy.WithOrigins(_origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
 

                });
            });
                       
            return services;
        }

        public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors(_policyName);
            return app;
        }
    }
}
